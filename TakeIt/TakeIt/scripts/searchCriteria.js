
function filterPosts() {
    var fromCountryId = $('#FromCountryId').val();
    var fromStateId = $('#FromStateId').val();
    var fromCityId = $('#FromCityId').val();
    var toCountryId = $('#ToCountryId').val();
    var toStateId = $('#ToStateId').val();
    var toCityId = $('#ToCityId').val();
    var fromDate = $('#fromDate').val();
    var toDate = $('#toDate').val();
    $("#postContentMain").load('/Post/FilterPosts', {
        fromCountryId: fromCountryId, fromStateId: fromStateId, fromCityId: fromCityId,
        toCountryId: toCountryId, toStateId: toStateId, toCityId: toCityId,
        fromDate: fromDate, toDate: toDate
    },
function (response, status, xhr)
{
    if (status == "error")
    {
        alert("An error occurred while loading the results.");
    }
});
   
}