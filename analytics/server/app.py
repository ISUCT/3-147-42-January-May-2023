from flask import Flask, request
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate
from datetime import datetime 
from models import *

app = Flask(__name__)
app.app_context().push()
app.config["SQLALCHEMY_DATABASE_URI"] = "postgresql://postgres:HR3F5w#Gm@localhost:5432/analitics_data"
db = SQLAlchemy(app)
migrate = Migrate(app, db)

@app.route('/', methods=['POST'])
def get_user(): 
    if request.method == 'POST':
        if request.is_json:
            current_date = datetime.now().date()
            user_data = request.get_json()
            date = db.session.query(Dates_Model).filter(Dates_Model.date==current_date).first()
            check_user = db.session.query(Users_Model).filter(Users_Model.username==user_data['username']).first()
            
            if date is None:
                db.session.query(Users_Model).update({ Users_Model.number_inputs: 0 })
                Dates_cell = Dates_Model(date=current_date)
                DAU_cell = DAU_Model(date=current_date, number_inputs=0)
                Retention_cell = Retention_Model(date=current_date, percentage_continuing_users=0)
                StickyFactor_cell = StickyFactor_Model(date=current_date, stickiness=0)
                AGT_cell = AGT_Model(date=current_date, average_game_time=0)
                TotalValues_cell = TotalValues_Model(date=current_date, total_inputs=0, all_time_users=0)
                db.session.add_all([Dates_cell, DAU_cell, Retention_cell, StickyFactor_cell, AGT_cell, TotalValues_cell])
            
            ex_DAU_cell = db.session.query(DAU_Model).filter(DAU_Model.date==current_date).first()
            ex_Retention_cell = db.session.query(Retention_Model).filter(Retention_Model.date==current_date).first()
            ex_TotalValues_cell = db.session.query(TotalValues_Model).filter(TotalValues_Model.date==current_date).first()
            ex_AGT_cell = db.session.query(AGT_Model).filter(AGT_Model.date==current_date).first()
            ex_StickyFactor_cell = db.session.query(StickyFactor_Model).filter(StickyFactor_Model.date==current_date).first()

            if check_user is None:
                user = Users_Model(username=user_data['username'], number_inputs=1, input_time=user_data['time'])
                db.session.add(user)
                ex_DAU_cell.number_inputs += 1 
                _user_isknown = False
            elif check_user.number_inputs == 0:
                ex_DAU_cell.number_inputs += 1
                _user_isknown = True
            else:
                _user_isknown = True

            total_users = db.session.query(Users_Model).count()

            
            ex_Retention_cell.percentage_continuing_users = ex_DAU_cell.number_inputs / total_users * 100
            

            if user_data['status'] == 'input':
                ex_TotalValues_cell.total_inputs += 1
                if _user_isknown:
                    check_user.input_time = user_data['time']
                    check_user.number_inputs += 1
                else:
                    user.input_time = user_data['time']
            else:
                output_time = user_data['time']
                ex_TotalValues_cell.all_time_users += (output_time - check_user.input_time)
                check_user.input_time = 0
                ex_AGT_cell.average_game_time = ex_TotalValues_cell.all_time_users / ex_DAU_cell.number_inputs

            ex_StickyFactor_cell.stickiness = ex_TotalValues_cell.total_inputs / total_users
            db.session.commit()
    return "user data received!"


if __name__ == "__main__":
    app.run(debug=True)
    