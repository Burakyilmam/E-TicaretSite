$(document).ready(function () {
    $(".counter").each(function () {
        var $this = $(this);
        var countTo = parseInt($this.attr("data-val"));

        $({ countNum: $this.text() }).animate(
            { countNum: countTo },
            {
                duration: 500,
                easing: "linear",
                step: function () {
                    $this.text(Math.floor(this.countNum));
                },
                complete: function () {
                    $this.text(this.countNum);
                },
            }
        );
    });
});
