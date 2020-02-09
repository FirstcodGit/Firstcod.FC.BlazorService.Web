function showToast(type, title, message) {

    switch (type) {
        case "Success":
            toastr.success(message, title);
            break;
        case "Error":
            toastr.error(message, title);
            break;
        case "Warning":
            toastr.warning(message, title);
            break;
        case "Info":
            toastr.info(message, title);
            break;
    }
}

function timer()
{
    setInterval(() => {

        setTime(new Date());
    }, 1000);
}

function setTime(time) {

    //toastr.error(time, "Time");
    $("#time").text(time);
}