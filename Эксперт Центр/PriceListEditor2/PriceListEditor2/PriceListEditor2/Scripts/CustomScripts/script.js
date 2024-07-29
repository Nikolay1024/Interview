/*
$(function () {
    $.datetimepicker.setLocale('ru');
    $(".header-datetimepicker").datetimepicker({
        format: 'd.m.Y',
        //step: 30,
        //minDate: 0,
        timepicker: false
    });
})
*/
var dtLanguage = {
    "processing": "Подождите...",
    "search": "Поиск:",
    "lengthMenu": "Показать _MENU_ записей",
    "info": "Записи с _START_ до _END_ из _TOTAL_ записей",
    "infoEmpty": "Записи с 0 до 0 из 0 записей",
    "infoFiltered": "(отфильтровано из _MAX_ записей)",
    "infoPostFix": "",
    "loadingRecords": "Загрузка записей...",
    "zeroRecords": "Записи отсутствуют.",
    "emptyTable": "В таблице отсутствуют данные",
    "paginate": {
        "first": "<<",
        "previous": "<",
        "next": ">",
        "last": ">>"
    },
    "aria": {
        "sortAscending": ": активировать для сортировки столбца по возрастанию",
        "sortDescending": ": активировать для сортировки столбца по убыванию"
    }
}
function dtConvFromJSON(data) {
    if (!data) return "";
    var dt = new Date(data.replace(/\D/g, "") * 1);
    return addLeadingZeros(dt.getDate(), 2) + "." +
        addLeadingZeros(dt.getMonth() + 1, 2) + "." +
        addLeadingZeros(dt.getFullYear(), 4) + " " +
        addLeadingZeros(dt.getHours(), 2) + ":" +
        addLeadingZeros(dt.getMinutes(), 2) + ":" +
        addLeadingZeros(dt.getSeconds(), 2);
};
function dtConvFromJSONShort(data) {
    if (!data) return "";
    var dt = new Date(data.replace(/\D/g, "") * 1);
    return addLeadingZeros(dt.getFullYear(), 4) + addLeadingZeros(dt.getMonth() + 1, 2) + addLeadingZeros(dt.getDate(), 2);
};
function addLeadingZeros(n, length) {
    var str = (n > 0 ? n : -n) + "";
    var zeros = "";
    for (var i = length - str.length; i > 0; i--) {
        zeros += "0";
    }

    zeros += str;
    return n >= 0 ? zeros : "-" + zeros;
};
function DisableIt(a, is) {
    a.prop('disabled', is);
}