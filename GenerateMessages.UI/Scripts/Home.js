$(document).ready(function () {
    LoadGuestsDropDown();
    LoadCompaniesDropDown();
    LoadTemplateDropDown();
    $('#generatedSection').hide();
    $('#templateSection').hide();
});

$('#submitButton').click(function (event) {
    ClearErrorMessages();
    GenerateMessage();
});

$('#templateSelection').change(function () {
    PreviewMessage();
    ClearGenMessage();
});

function PreviewMessage() {
    var messagePreview = $('#messagePreview');
    messagePreview.empty();
    var templateId = $('#templateSelection').val();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:59560/api/index/template/' + templateId,
        success: function (template) {
            var preview = '<p>' + template.Message + '</p>';
            messagePreview.append(preview);
            $('#templateSection').show();
        },
        error: function (jqXHR, testStatus, errorThrow) {
            alert('error previewing message');
        }
    });
}

$(document).on('click', '#newTemplateButton', function () {
    ClearErrorMessages();
    ClearGenMessage();
    var templateName = $('#newTemplateName').val();
    var templateMessage = $('#newMessage').val();

    if (templateName == '' || templateMessage == '' || templateName == ' ' || templateMessage == ' ') {
        $('#errorMessages').append('<p>Template name and message is required to create new template.</p>');
    }
    else {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:59560/api/index/template/add',
            data: JSON.stringify({
                Name: templateName,
                Message: templateMessage
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {

                $('#templateSelection').empty();
                ReloadTemplateDropDown();
            },
            error: function (jqXHR, testStatus, errorThrow) {
                alert('error creating template');

            }
        });
    }
});


$(document).on('click', '.placeHolderButton', function () {
    var oldText = $('#newMessage').val();
    var newText = oldText + $(this).data('placeholder');
    $('#newMessage').val(newText);
});

$(document).on('click', '#greeting', function () {
    $('#newMessage').val('{Greeting}');
});

function LoadGuestsDropDown() {
    var guestSelection = $('#guestSelection');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:59560/api/index/guests',
        success: function (guestArray) {
            $.each(guestArray, function (index, guest) {
                var selection = '<option value= "' + guest.Id + '">' + guest.LastName + ', ' + guest.FirstName + '</option>';
                guestSelection.append(selection);
            });
        },
        error: function (jqXHR, testStatus, errorThrow) {
            alert('error loading guest drop down');
        }
    });
}

function LoadCompaniesDropDown() {
    var companySelection = $('#companySelection');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:59560/api/index/companies',
        success: function (companyArray) {
            $.each(companyArray, function (index, company) {
                var selection = '<option value= "' + company.Id + '">' + company.Company + '</option>';
                companySelection.append(selection);
            });
        },
        error: function (jqXHR, testStatus, errorThrow) {
            alert('error loading company drop down ');
        }
    });
}

function ReloadTemplateDropDown() {
    $('#newTemplateName').val('');
    $('#newMessage').val('');
    var selection = $('#templateSelection');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:59560/api/index/templates',
        success: function (templateArray) {
            $.each(templateArray, function (index, template) {
                var option = '<option value= "' + template.Id + '">' + template.Name + '</option>';
                selection.append(option);
                selection.trigger("chosen:updated");
            });
        },
        complete: function () {
            SelectAndDisplayTemplate();
        },
        error: function (jqXHR, testStatus, errorThrow) {
            alert('error loading template dropdown');
        }
    });
}

function SelectAndDisplayTemplate() {
    var count = $('#templateSelection').children('option').length;
    $('#templateSelection').val(count);
    PreviewMessage();
}

function LoadTemplateDropDown() {
    var selection = $('#templateSelection');

    $.ajax({
        type: 'GET',
        url: 'http://localhost:59560/api/index/templates',
        success: function (templateArray) {
            $.each(templateArray, function (index, template) {
                var option = '<option value= "' + template.Id + '">' + template.Name + '</option>';
                selection.append(option);
                selection.trigger("chosen:updated");
            });
        },
        error: function (jqXHR, testStatus, errorThrow) {
            alert('error loading template dropdown');
        }
    });
}

function GenerateMessage() {
    var generatedMessage = $('#generatedMessage');
    generatedMessage.empty();
    var guestId = $('#guestSelection').val();
    var companyId = $('#companySelection').val();
    var templateName = $('#templateSelection').val();

    if (guestId == null || companyId == null || templateName == null) {
        $('#errorMessages').append('Guest, Company and Message template are all requried for generating message.');
    }
    else {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:59560/api/index/generate/' + guestId + '/' + companyId + '/' + templateName,
            success: function (message) {

                generatedMessage.append('<p>' + message + '</p>');
                $('#generatedSection').show();
            },
            error: function (jqXHR, testStatus, errorThrow) {
                alert('error generating message');
            }
        });
    }
}

function ClearErrorMessages() {
    $('#errorMessages').empty();
}

function ClearGenMessage() {
    $('#generatedMessage').empty();
}
