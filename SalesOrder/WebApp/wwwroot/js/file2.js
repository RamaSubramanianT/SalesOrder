$(document).ready(function () {
    $('#insertButton').click(function (e) {
        e.preventDefault(); // Prevent default button behavior

        Swal.fire({
            title: "Do you want to save the changes?",
            showDenyButton: true,
            showCancelButton: true,
            confirmButtonText: "Save",
            denyButtonText: `Don't save`
        }).then((result) => {
            if (result.isConfirmed) {
                // If user confirms, submit the form
                $('form').unbind('submit').submit(); // Unbind previous submit handler to prevent infinite loop
            } else if (result.isDenied) {
                Swal.fire("Changes are not saved", "", "info");
            }
        });
    });

});