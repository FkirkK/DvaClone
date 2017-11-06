$(document).on('change', '#JudgeDropDown', function () {
    var FeatureValue = $('#JudgeDropDown').val();
    var ClassificationValue = $('#AlgorithmCountDropDown').val();

    if (FeatureValue !== "" && ClassificationValue !== "")
        $('#Submit').removeAttr('disabled');
    else 
        $('#Submit').attr('disabled', 'disabled');
});

$(document).on('change', '#AlgorithmCountDropDown', function () {
    var FeatureValue = $('#JudgeDropDown').val();
    var ClassificationValue = $('#AlgorithmCountDropDown').val();

    if (FeatureValue !== "" && ClassificationValue !== "")
        $('#Submit').removeAttr('disabled');
    else
        $('#Submit').attr('disabled', 'disabled');
});