function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


function loadHTMLPage(path, container) {

    var xhr = typeof XMLHttpRequest != 'undefined' ? new XMLHttpRequest() : new ActiveXObject('Microsoft.XMLHTTP');
    xhr.open('get', path, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            document.getElementById(container).innerHTML = xhr.responseText;
        }
    }
    xhr.send();

}


function setActiveMenuPane(elementID) {

    var menuPanes = document.querySelectorAll('.menu-pane');

    // -1 because last element is a dropdown.
    for (i = 0; i < menuPanes.length; i++) {

        menuPanes[i].className = "menu-pane";

    }

    var element = document.getElementById(elementID);

    element.className = "menu-pane active-pane";


}


var previousButton = document.getElementById('menu-nav-previous');
var nextButton = document.getElementById('menu-nav-next');
var navmenutitle = document.getElementById('menu-nav-title');
var navmenutitles = ['Choose your bun', 'Beef it up', 'Say cheese!', 'Pimp it with sauce', 'Feeling Extra?']
var currentMenuPane = 1;

function NextMenuPane() {

    currentMenuPane++;

    if(currentMenuPane > 5){
        currentMenuPane = 1;
    }


}

function PreviousMenuPane() {

    currentMenuPane--;

    if(currentMenuPane < 1){
        currentMenuPane = 5;
    }

}

previousButton.onclick = function(){

    PreviousMenuPane();
    console.log(currentMenuPane);

    loadHTMLPage('./menu/' + currentMenuPane + '.html', 'dynamic-content');

    navmenutitle.innerText = navmenutitles[currentMenuPane-1];

    setActiveMenuPane('menu-pane' + currentMenuPane);

}

nextButton.onclick = function(){

    NextMenuPane();
    console.log(currentMenuPane);

    loadHTMLPage('./menu/' + currentMenuPane + '.html', 'dynamic-content');

    navmenutitle.innerText = navmenutitles[currentMenuPane-1];

    setActiveMenuPane('menu-pane' + currentMenuPane);
}