$(() => {
    //should have sep post and get - post conf/decl and then sep get counts
    $("#confirm").on('click', function () {
        const id = $(this).data("id");
        $.post("/home/changestatus?confirm=true", { id }, function (counts) {
            updated(counts);
        });
    });

    $("#decline").on('click', function () {
        const id = $(this).data("id");
        $.post("/home/changestatus?confirm=false", { id }, function (counts) {
            updated(counts);
        });
    });

    const updated = counts => {
        $("#confirm").remove();
        $("#decline").remove();
        console.log(counts);
        document.getElementById('pending-ct').textContent = counts.pending;
        document.getElementById('confirmed-ct').textContent = counts.confirmed;
        document.getElementById('declined-ct').textContent = counts.declined;
        //or could just do $("#pending-ct").text = counts.pending; ....

    }

    
});