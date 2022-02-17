jQuery(document).ready(function () {

    var modal = document.getElementById('myModal');
    //var img = document.getElementById('nope');
    var img = document.getElementsByClassName('img-fluid img-thumbnail');
    var modalImg = document.getElementById("modalImage");
    var captionText = document.getElementById("caption");
    img.onclick = function () {
        modal.style.display = "block";
        modalImg.src = this.src;
        captionText.innerHTML = this.alt;
    };

    var span = document.getElementsByClassName("close")[0];

    span.onclick = function () {
        modal.style.display = "none";
    };
});