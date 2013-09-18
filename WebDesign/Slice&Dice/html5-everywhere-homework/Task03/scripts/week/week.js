// HTML5 Week polyfill | Jonathan Stipe | https://github.com/jonstipe/week-polyfill

(function(){(function($){$.fn.inputWeek=function(){var advanceWeek,compareWeeks,dateIsInStep,decrement,distanceBetweenWeeks,getFirstDayOfWeek,getLastDayOfWeek,getThursdayOfSameWeek,getThursdayOfWeek,getWeekOfDate,increment,makeWeekDisplayString,makeWeekString,readWeek,regressWeek,stepNormalize;readWeek=function(w_str){var matchData,weekPart,yearPart;if(/^\d{4,}-W\d\d$/.test(w_str)){matchData=/^(\d+)-W(\d+)$/.exec(w_str);yearPart=parseInt(matchData[1],10);weekPart=parseInt(matchData[2],10);return{year:yearPart,week:weekPart};}else{throw"Invalid week string: "+w_str;}};makeWeekString=function(week_obj){var w_arr;w_arr=[week_obj['year'].toString()];w_arr.push('-W');if(week_obj['week']<10){w_arr.push('0');}
w_arr.push(week_obj['week'].toString());return w_arr.join('');};makeWeekDisplayString=function(week_obj,elem){var $elem,end_date,month_names,start_date,week_arr;$elem=$(elem);month_names=$elem.datepicker("option","monthNames");start_date=getFirstDayOfWeek(week_obj);end_date=getLastDayOfWeek(week_obj);week_arr=[week_obj['year'].toString()];week_arr.push(' Week ');week_arr.push(week_obj['week']);week_arr.push(': ');week_arr.push(month_names[start_date.getMonth()]);week_arr.push(' ');week_arr.push(start_date.getDate().toString());week_arr.push(' - ');if(start_date.getMonth()!==end_date.getMonth()){week_arr.push(month_names[end_date.getMonth()]);week_arr.push(' ');}
week_arr.push(end_date.getDate().toString());return week_arr.join('');};getThursdayOfSameWeek=function(dateObj){var thursOfWeek;thursOfWeek=new Date(dateObj.getTime());if(dateObj.getDay()===0){thursOfWeek.setDate(dateObj.getDate()-3);}else if(dateObj.getDay()>4){thursOfWeek.setDate(dateObj.getDate()-(dateObj.getDay()-3));}else if(dateObj.getDay()<4){thursOfWeek.setDate(dateObj.getDate()+(4-dateObj.getDay()));}
return thursOfWeek;};getWeekOfDate=function(dateObj){var thursOfWeek;thursOfWeek=getThursdayOfSameWeek(dateObj);return{year:thursOfWeek.getFullYear(),week:$.datepicker.iso8601Week(thursOfWeek)};};getFirstDayOfWeek=function(week_obj){var kDate;if(week_obj['week']>0&&week_obj['week']<=53){kDate=getThursdayOfSameWeek(new Date(week_obj['year'],0,1));kDate.setDate(kDate.getDate()+(week_obj['week']*7)-2);return kDate;}else{throw"Week number is out of range.";}};getLastDayOfWeek=function(week_obj){var kDate;if(week_obj['week']>0&&week_obj['week']<=53){kDate=getThursdayOfSameWeek(new Date(week_obj['year'],0,1));kDate.setDate(kDate.getDate()+(week_obj['week']*7)+4);return kDate;}else{throw"Week number is out of range.";}};getThursdayOfWeek=function(week_obj){var kDate;if(week_obj['week']>0&&week_obj['week']<=53){kDate=getThursdayOfSameWeek(new Date(week_obj['year'],0,1));kDate.setDate(kDate.getDate()+(week_obj['week']*7));return kDate;}else{throw"Week number is out of range.";}};compareWeeks=function(week1,week2){if(week1['year']>week2['year']){return-1;}else if(week1['year']===week2['year']){if(week1['week']>week2['week']){return-1;}else if(week1['week']===week2['week']){return 0;}else{return 1;}}else{return 1;}};distanceBetweenWeeks=function(week1,week2){var week1day,week2day;week1day=getThursdayOfWeek(week1);week2day=getThursdayOfWeek(week2);return Math.round((week2day.getTime()-week1day.getTime())/604800000);};dateIsInStep=function(date,min,step){var startWeek,weekDist,weekObj;weekObj=getWeekOfDate(date);startWeek=(min!=null)?min:{year:1970,week:1};weekDist=distanceBetweenWeeks(startWeek,weekObj);return(weekDist%step)===0;};advanceWeek=function(inWeek,amt){var thursday;thursday=getThursdayOfWeek(inWeek);thursday.setDate(thursday.getDate()+(amt*7));return{year:thursday.getFullYear(),week:$.datepicker.iso8601Week(thursday)};};regressWeek=function(inWeek,amt){var thursday;thursday=getThursdayOfWeek(inWeek);thursday.setDate(thursday.getDate()-(amt*7));return{year:thursday.getFullYear(),week:$.datepicker.iso8601Week(thursday)};};increment=function(hiddenField,weekBtn,calendarDiv){var $hiddenField,max,step,value;$hiddenField=$(hiddenField);value=readWeek($hiddenField.val());step=$hiddenField.data("step");max=$hiddenField.data("max");if(!(step!=null)||step==='any'){value=advanceWeek(value,1);}else{value=advanceWeek(value,step);}
if((max!=null)&&compareWeeks(value,max)===-1){value['year']=max['year'];value['week']=max['week'];}
value=stepNormalize(value,hiddenField);$hiddenField.val(makeWeekString(value)).change();$(weekBtn).text(makeWeekDisplayString(value,calendarDiv));$(calendarDiv).datepicker("setDate",getFirstDayOfWeek(value));return null;};decrement=function(hiddenField,weekBtn,calendarDiv){var $hiddenField,min,step,value;$hiddenField=$(hiddenField);value=readWeek($hiddenField.val());step=$hiddenField.data("step");min=$hiddenField.data("min");if(!(step!=null)||step==='any'){value=regressWeek(value,1);}else{value=regressWeek(value,step);}
if((min!=null)&&compareWeeks(value,min)===1){value['year']=min['year'];value['week']=min['week'];}
value=stepNormalize(value,hiddenField);$hiddenField.val(makeWeekString(value)).change();$(weekBtn).text(makeWeekDisplayString(value,calendarDiv));$(calendarDiv).datepicker("setDate",getFirstDayOfWeek(value));return null;};stepNormalize=function(inWeek,hiddenField){var $hiddenField,min,step,stepDiff,stepDiff2;$hiddenField=$(hiddenField);step=$hiddenField.data("step");min=$hiddenField.data("min");if((step!=null)&&step!=='any'){stepDiff=distanceBetweenWeeks((min!=null?min:{year:1970,week:1}),inWeek)%step;if(stepDiff===0){return inWeek;}else{stepDiff2=step-stepDiff;if(stepDiff>stepDiff2){return advanceWeek({year:inWeek['year'],week:inWeek['week']},stepDiff2);}else{return regressWeek({year:inWeek['year'],week:inWeek['week']},stepDiff);}}}else{return inWeek;}};$(this).filter('input[type="week"]').each(function(){var $calendarContainer,$calendarDiv,$hiddenField,$this,$weekBtn,calendarContainer,calendarDiv,className,closeFunc,hiddenField,max,min,step,style,value,weekBtn;$this=$(this);value=$this.attr('value');min=$this.attr('min');max=$this.attr('max');step=$this.attr('step');className=$this.attr('class');style=$this.attr('style');if((value!=null)&&/^\d{4,}-W\d\d$/.test(value)){value=readWeek(value);}else{value=new Date();value={year:value.getFullYear(),week:$.datepicker.iso8601Week(value)};}
if(min!=null){min=readWeek(min);if(compareWeeks(value,min)===1){value['year']=min['year'];value['week']=min['week'];}}
if(max!=null){max=readWeek(max);if(compareWeeks(value,max)===-1){value['year']=max['year'];value['week']=max['week'];}}
if((step!=null)&&step!=='any'){step=parseInt(step,10);}else{step=1;}
hiddenField=document.createElement('input');$hiddenField=$(hiddenField);$hiddenField.attr({type:"hidden",name:$this.attr('name'),value:makeWeekString(value)});$hiddenField.data({min:min,max:max,step:step});value=stepNormalize(value,hiddenField);$hiddenField.attr('value',makeWeekString(value));calendarContainer=document.createElement('span');$calendarContainer=$(calendarContainer);if(className!=null){$calendarContainer.attr('class',className);}
if(style!=null){$calendarContainer.attr('style',style);}
calendarDiv=document.createElement('div');$calendarDiv=$(calendarDiv);$calendarDiv.css({display:'none',position:'absolute'});weekBtn=document.createElement('button');$weekBtn=$(weekBtn);$weekBtn.addClass('week-datepicker-button');$this.replaceWith(hiddenField);$calendarContainer.insertAfter(hiddenField);$weekBtn.appendTo(calendarContainer);$calendarDiv.appendTo(calendarContainer);$calendarDiv.datepicker({dateFormat:'MM dd, yy',showButtonPanel:true,showWeek:true,firstDay:1,beforeShowDay:function(date){min=$hiddenField.data('min');step=$hiddenField.data('step');if((step!=null)&&step!=='any'){return[dateIsInStep(date,min,step),""];}else{return[true,""];}}});$weekBtn.text(makeWeekDisplayString(value,calendarDiv));if(min!=null){$calendarDiv.datepicker("option","minDate",getFirstDayOfWeek(min));}
if(max!=null){$calendarDiv.datepicker("option","maxDate",getLastDayOfWeek(max));}
if(Modernizr.csstransitions){calendarDiv.className="week-calendar-dialog week-closed";$weekBtn.click(function(event){$calendarDiv.off('transitionend oTransitionEnd webkitTransitionEnd MSTransitionEnd');calendarDiv.style.display='block';calendarDiv.className="week-calendar-dialog week-open";event.preventDefault();return false;});closeFunc=function(event){var transitionend_function;if(calendarDiv.className==="week-calendar-dialog week-open"){transitionend_function=function(event,ui){calendarDiv.style.display='none';$calendarDiv.off("transitionend oTransitionEnd webkitTransitionEnd MSTransitionEnd",transitionend_function);return null;};$calendarDiv.on("transitionend oTransitionEnd webkitTransitionEnd MSTransitionEnd",transitionend_function);calendarDiv.className="week-calendar-dialog week-closed";}
if(event!=null){event.preventDefault();}
return null;};}else{$weekBtn.click(function(event){$calendarDiv.fadeIn('fast');event.preventDefault();return false;});closeFunc=function(event){$calendarDiv.fadeOut('fast');if(event!=null){event.preventDefault();}
return null;};}
$calendarDiv.mouseleave(closeFunc);$calendarDiv.datepicker("option","onSelect",function(dateText,inst){var dateObj,weekObj;dateObj=$.datepicker.parseDate('MM dd, yy',dateText);weekObj=getWeekOfDate(dateObj);$hiddenField.val(makeWeekString(weekObj)).change();$weekBtn.text(makeWeekDisplayString(weekObj,calendarDiv));closeFunc();return null;});$calendarDiv.datepicker("setDate",getFirstDayOfWeek(value));$weekBtn.on({DOMMouseScroll:function(event){if(event.originalEvent.detail<0){increment(hiddenField,weekBtn,calendarDiv);}else{decrement(hiddenField,weekBtn,calendarDiv);}
event.preventDefault();return null;},mousewheel:function(event){if(event.originalEvent.wheelDelta>0){increment(hiddenField,weekBtn,calendarDiv);}else{decrement(hiddenField,weekBtn,calendarDiv);}
event.preventDefault();return null;},keypress:function(event){if(event.keyCode===38){increment(hiddenField,weekBtn,calendarDiv);event.preventDefault();}else if(event.keyCode===40){decrement(hiddenField,weekBtn,calendarDiv);event.preventDefault();}
return null;}});return null;});return this;};$(function(){if(!Modernizr.inputtypes.week){$('input[type="week"]').inputWeek();}
return null;});return null;})(jQuery);}).call(this);