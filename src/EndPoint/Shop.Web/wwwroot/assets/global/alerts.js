function deleteItem(url, errorTitle, errorText) {
    if (errorTitle == null || errorTitle == "undefined") {
        errorTitle = "عملیات ناموفق";
    }
    if (errorText == null || errorText == "undefined") {
        errorText = "";
    }
    Swal.fire({
        title: "هشدار !!",
        text: "آیا از حذف اطمینان دارید ؟",
        icon: "warning",
        confirmButtonText: "بله",
        showCancelButton: true,
        cancelButtonText: "خیر",
        preConfirm: () => {
            $.ajax({
                url: url,
                type: "get",
                beforeSend: function () {
                    $(".loading").show();
                },
                complete: function () {
                    $(".loading").hide();
                },
                error: function (data) {
                    console.log(data.mess);
                    ErrorAlert("مشکلی در عملیات رخ داده", "لطفا در زمان دیگری امتحان کنید");
                }
            }).done(function (data) {
                data = JSON.parse(data);
                if (data.Status === 200) {
                    Swal.fire({
                        title: data.Title,
                        text: data.Message == null ? "عملیات با موفقیت انجام شد" : data.Message,
                        icon: "success",
                        confirmButtonText: "باشه",
                    }).then(function (res) {
                        if (data.IsReloadPage === true) {
                            location.reload();
                        }
                    });
                } else if (data.Status === 10) {
                    ErrorAlert(data.Title, data.Message);
                } else if (data.Status === 404) {
                    Warning(data.Title, data.Message);
                }
            });
        }
    });
}
function Question(url, QuestionTitle, QuestionText, successText, callBack) {
    if (QuestionTitle == null || QuestionTitle == "undefined") {
        QuestionTitle = "آیا از انجام عملیات اطمینان دارید؟";
    }
    if (QuestionText == null || QuestionText == "undefined") {
        QuestionText = "";
    }

    Swal.fire({
        title: QuestionTitle,
        text: QuestionText,
        icon: "question",
        confirmButtonText: "بله",
        showCancelButton: true,
        cancelButtonText: "خیر",
        preConfirm: () => {
            $.ajax({
                url: url,
                type: "get",
                beforeSend: function () {
                    $(".loading").show();
                },
                complete: function () {
                    $(".loading").hide();
                },
                error: function (data) {
                    ErrorAlert("مشکلی در اعملیات رخ داده", "لطفا در زمان دیگری امتحان کنید");
                }
            }).done(function (data) {
                try {
                    data = JSON.parse(data);
                    if (data.Status === 200) {
                        Swal.fire({
                            title: data.Title,
                            text: successText == null ? data.Message : successText,
                            icon: "success",
                            confirmButtonText: "باشه",
                        }).then(function (res) {
                            if (data.IsReloadPage === true) {
                                location.reload();
                            } else {
                                if (callBack) {
                                    callBack(data.Status);
                                }
                            }
                        });
                    } else if (data.Status === 10) {
                        ErrorAlert(data.Title, data.Message);
                    } else if (data.Status === 404) {
                        Warning(data.Title, data.Message);
                    }
                } catch (ex) {
                    ErrorAlert();
                }
            });
        }
    });
}
function Success(Title, description, isReload = false) {
    if (Title == null || Title == "undefined") {
        Title = "عملیات با موفقیت انجام شد";
    }
    if (description == null || description == "undefined") {
        description = "";
    }
    Swal.fire({
        title: Title,
        html: description,
        icon: "success",
        confirmButtonText: "باشه",
    }).then((result) => {
        if (isReload === true) {
            location.reload();
        }
    });
}
function Info(Title, description) {
    if (Title == null || Title == "undefined") {
        Title = "توجه";
    }
    if (description == null || description == "undefined") {
        description = "";
    }
    Swal.fire({
        title: Title,
        html: description,
        icon: "info",
        confirmButtonText: "باشه"
    });
}
function ErrorAlert(Title, description, isReload = false) {
    if (Title == null || Title == "undefined") {
        Title = "مشکلی در عملیات رخ داده است";
    }
    if (description == null || description == "undefined") {
        description = "";
    }
    Swal.fire({
        title: Title,
        html: description,
        icon: "error",
        confirmButtonText: "باشه"
    }).then((result) => {
        if (isReload === true) {
            location.reload();
        }
    });
}
function Warning(Title, description, isReload = false) {
    if (Title == null || Title == "undefined") {
        Title = "مشکلی در عملیات رخ داده است";
    }
    if (description == null || description == "undefined") {
        description = "";
    }
    Swal.fire({
        title: Title,
        html: description,
        icon: "warning",
        confirmButtonText: "باشه"
    }).then((result) => {
        if (isReload === true) {
            location.reload();
        }
    });
}