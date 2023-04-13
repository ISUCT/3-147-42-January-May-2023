function CityChange()
{
document.getElementById('adress').innerHTML = document.getElementById(document.getElementById('city').value).innerHTML
}
//Контейнер форм (включает все формы)
var $form_wrapper = $('#form_wrapper'),
//Текущая форма - имеет класс active
$currentForm  = $form_wrapper.children('form.active'),
//Ссылка на изменение формы
$linkform   = $form_wrapper.find('.linkform');
$form_wrapper.children('form').each(function(i){
  var $theForm  = $(this);
  //Решение проблемы с выводом при использовании fadeIn fadeOut
  if(!$theForm.hasClass('active'))
    $theForm.hide();
  $theForm.data({
    width : $theForm.width(),
    height  : $theForm.height()
  });
});
setWrapperWidth();
$linkform.bind('click',function(e){
  var $link = $(this);
  var target  = $link.attr('rel');
  $currentForm.fadeOut(400,function(){
    //Удаляем класс active с текущей формы
    $currentForm.removeClass('active');
    //Новая текущая форма
    $currentForm= $form_wrapper.children('form.'+target);
    //Анимируем изменения контейнера
    $form_wrapper.stop()
           .animate({
            width : $currentForm.data('width') + 'px',
            height  : $currentForm.data('height') + 'px'
           },500,function(){
            //Новая форма получает класс active
            $currentForm.addClass('active');
            //Выводим новую форму
            $currentForm.fadeIn(400);
           });
  });
  e.preventDefault();
});
function setWrapperWidth(){
  $form_wrapper.css({
    width : $currentForm.data('width') + 'px',
    height  : $currentForm.data('height') + 'px'
  });
}
$form_wrapper.find('input[type="submit"]')
       .click(function(e){
        e.preventDefault();
       });  