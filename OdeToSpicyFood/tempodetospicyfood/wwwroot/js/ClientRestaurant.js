$(function () {

    // Normally, I would grab this data via API, but for the sake of this demo I'm hardcoding here
    var cuisines = ["Unknown", "American", "Mexican", "Chinese", "Japanese", "Italian", "Indian", "Mediterranean"]

    $.ajax("/api/restaurants/", { method: "get" })
        .then(function (response) {
            $("#restaurants").dataTable({
                data: response,
                columns: [
                    { "data": "name" },
                    {
                        "data": function (data) {
                            return (data.street + ", " + data.city + " " + data.state + " " + data.zip);
                        }
                    },
                    {
                        "data": "cuisine", "render": function (data) {
                            return cuisines[data];
                        }
                    },
                    { "data": "rating" }
                ]
            });
        });
});