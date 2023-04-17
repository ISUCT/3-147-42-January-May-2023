from app import db


class Users_Model(db.Model):
    __tablename__ = 'users'

    id = db.Column(db.Integer, primary_key=True)
    username = db.Column(db.String(50))
    number_inputs = db.Column(db.Integer)
    input_time = db.Column(db.Float)

    def __init__(self, username, number_inputs, input_time):
        self.username = username
        self.number_inputs = number_inputs
        self.input_time = input_time

class Dates_Model(db.Model):
    __tablename__ = 'dates'

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date)

    def __init__(self, date):
        self.date = date


class DAU_Model(db.Model):
    __tablename__ = 'daily_active_users'

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date)
    number_inputs = db.Column(db.Integer)

    def __init__(self, date, number_inputs):
        self.date = date
        self.number_inputs = number_inputs 


class Retention_Model(db.Model):
    __tablename__ = 'retention'

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date)
    percentage_continuing_users = db.Column(db.Float)

    def __init__(self, date, percentage_continuing_users):
        self.date = date
        self.percentage_continuing_users = percentage_continuing_users


class StickyFactor_Model(db.Model):
    __tablename__ = 'sticky_factor'      

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date)
    stickiness = db.Column(db.Float)
    
    def __init__(self, date, stickiness):
        self.date = date
        self.stickiness = stickiness


class AGT_Model(db.Model):
    __tablename__ = 'average_game_time'

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date)
    average_game_time = db.Column(db.Float)

    def __init__(self, date, average_game_time):
        self.date = date,
        self.average_game_time = average_game_time

class TotalValues_Model(db.Model):
    __tablename__ = 'total_values'

    id = db.Column(db.Integer, primary_key=True)
    date = db.Column(db.Date)
    total_inputs = db.Column(db.Integer)
    all_time_users = db.Column(db.Float)    

    def __init__(self, date, total_inputs, all_time_users):
        self.date = date
        self.total_inputs = total_inputs
        self.all_time_users = all_time_users