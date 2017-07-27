function FillState(a) {
    if (a == 1) {
        var stateId = $('#FromCountryId').val();
    }
    else {
        var stateId = $('#ToCountryId').val();
    }
    $.ajax({
        url: '/Post/FillState',
        type: "GET",
        dataType: "JSON",
        data: { CountryId: stateId },
        success: function (states) {
            if (a == 1) {
                $("#FromStateId").html('<option value="" >Select State</option>'); // clear before appending new list 
                $.each(states, function (i, state) {
                    $("#FromStateId").append(
                        $('<option></option>').val(state.id).html(state.Name));
                });
            }
            else {
                $("#ToStateId").html('<option value="" >Select State</option>'); // clear before appending new list 
                $.each(states, function (i, state) {
                    $("#ToStateId").append(
                        $('<option></option>').val(state.id).html(state.Name));
                });
            }

        }
    });

} function FillCity(a) {
    if (a == 1) {
        var stateId = $('#FromStateId').val();
    }
    else {
        var stateId = $('#ToStateId').val();
    }
    $.ajax({
        url: '/Post/FillCity',
        type: "GET",
        dataType: "JSON",
        data: { StateId: stateId },
        success: function (cities) {
            if (a == 1) {
                $("#FromCityId").html('<option value="">Select City</option>'); // clear before appending new list 
                $.each(cities, function (i, city) {
                    $("#FromCityId").append(
                        $('<option></option>').val(city.id).html(city.Name));
                });
            } else {
                $("#ToCityId").html('<option value="">Select City</option>'); // clear before appending new list 
                $.each(cities, function (i, city) {
                    $("#ToCityId").append(
                        $('<option></option>').val(city.id).html(city.Name));
                });
            }
        }
    });

}