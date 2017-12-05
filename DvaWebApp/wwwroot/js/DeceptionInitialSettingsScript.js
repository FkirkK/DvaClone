$(document).on('change', '#CommitteeDropDown', function () {
    var FeatureValue = $('#CommitteeDropDown').val();
    var ClassificationValue = $('#AlgorithmCountDropDown').val();

    if (FeatureValue !== "" && ClassificationValue !== "")
        $('#Submit').removeAttr('disabled');
    else 
        $('#Submit').attr('disabled', 'disabled');
});

$(document).on('change', '#AlgorithmCountDropDown', function () {
    var FeatureValue = $('#CommitteeDropDown').val();
    var ClassificationValue = $('#AlgorithmCountDropDown').val();

    if (FeatureValue !== "" && ClassificationValue !== "")
        $('#Submit').removeAttr('disabled');
    else
        $('#Submit').attr('disabled', 'disabled');
});