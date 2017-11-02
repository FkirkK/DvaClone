var algoCount;

function SetAlgoCount(count) {
    algoCount = Number(count);
}

$(document).on('change', function () {
    var IsAnyDropDownEmpty = false;

    for (var i = 1; i <= algoCount; i++) {
        var FeatureValue = $('#FeatureDropDown'+i).val();
        var ClassificationValue = $('#ClassificationDropDown'+i).val();

        if (FeatureValue === "" || ClassificationValue === "")
        {
            IsAnyDropDownEmpty = true;
            break;
        }
    }

    if (!IsAnyDropDownEmpty)
        $('#Submit').removeAttr('disabled');
    else
        $('#Submit').attr('disabled', 'disabled');
    
});