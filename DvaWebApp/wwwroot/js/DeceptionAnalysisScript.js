$(document).on('change', '#FeatureDropDown', function () {
    var FeatureValue = $('#FeatureDropDown').val();
    var ClassificationValue = $('#ClassificationDropDown').val();

    if (FeatureValue !== "" && ClassificationValue !== "")
        $('#Submit').removeAttr('disabled');
    else 
        $('#Submit').attr('disabled', 'disabled');
});

$(document).on('change', '#ClassificationDropDown', function () {
    var FeatureValue = $('#FeatureDropDown').val();
    var ClassificationValue = $('#ClassificationDropDown').val();

    if (FeatureValue !== "" && ClassificationValue !== "")
        $('#Submit').removeAttr('disabled');
    else
        $('#Submit').attr('disabled', 'disabled');
});