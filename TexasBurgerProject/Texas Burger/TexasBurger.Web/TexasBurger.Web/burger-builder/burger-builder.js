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

function getActiveBun(){

    var candidates = document.querySelectorAll(".carousel-inner .carousel-item");

    for(i = 0; i < candidates.length; i++){
        if(candidates[i].className === "carousel-item active"){
            return candidates[i].querySelector("h3").innerText;
        }
    }

   

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
var navmenutitles = ['Choose your bun', 'Beef it up', 'Say cheese!', 'Pimp it with sauce', 'Feeling Extra?'];
var currentMenuPane = 1;

var burger = {
    "bun": "",
    "beefs": [],
    "cheeses": [],
    "sauces": [],
    "extras": []    

};

var beef = {
    "name": "",
    "quantity": 0
};

var cheese = {
    "name": "",
    "quantity": 0
};

var sauce = {
    "name": "",
    "quantity": 0
};

var extra = {
    "name": "",
    "quantity": 0
}

/*
burger.bun = "Sesame seed bun";
burger.beefs =
[
    { "name": "Angry beef", "quantitiy": 2 },
    { "name": "Texas beef", "quantity": 4}
];

burger.cheeses =
[
    { "name": "Cheddar", "quantity": 2 },
    { "name": "Swiss", "quantity": 5 }
];

burger.sauces =
[
    { "name": "Ketchup", "quantity": 1 },
    { "name": "Aioli", "quantity": 2 }
    ];

burger.extras =
[
    { "name": "Grilled onions", "quantity": 2 },
    { "name": "Bacon strips", "quantity": 1 }
];
*/


function getSelectedBeefs(){

    var objects = document.querySelectorAll(".cheeseitem");
    var returnval = [];


    for(i = 0; i < objects.length; i++){

       var name = objects[i].querySelector("p").innerText;
       var qty = objects[i].querySelector("input").value;

      

        
        if(qty > 0){

            //burger.beefs.push({"name": name, "quantity": qty});
            returnval.push({"name": name, "quantity": qty});
            console.log("Name: " + name + "Qty: " + qty);

        }
        
    }

    return returnval;

}

function getSelectedCheeses(){

    var objects = document.querySelectorAll(".cheeseitem");
    var returnval = [];

    for(i = 0; i < objects.length; i++){

        var name = objects[i].querySelector("p").innerText;
        var qty = objects[i].querySelector("input").value;
          
         if(qty > 0){
 
             //burger.beefs.push({"name": name, "quantity": qty});
             returnval.push({"name": name, "quantity": qty});
             console.log("Name: " + name + "Qty: " + qty);
 
         }
         
     }
 
     return returnval;

}

function getSelectedSauces(){

    var objects = document.querySelectorAll(".cheeseitem");
    var returnval = [];

    for(i = 0; i < objects.length; i++){

        var name = objects[i].querySelector("p").innerText;
        var qty = objects[i].querySelector("input").value;
          
         if(qty > 0){
 
             //burger.beefs.push({"name": name, "quantity": qty});
             returnval.push({"name": name, "quantity": qty});
             console.log("Name: " + name + "Qty: " + qty);
 
         }
         
     }
 
     return returnval;

}

function getSelectedExtras(){

    var objects = document.querySelectorAll(".cheeseitem");
    var returnval = [];

    for(i = 0; i < objects.length; i++){

        var name = objects[i].querySelector("p").innerText;
        var qty = objects[i].querySelector("input").value;
          
         if(qty > 0){
 
             //burger.beefs.push({"name": name, "quantity": qty});
             returnval.push({"name": name, "quantity": qty});
             console.log("Name: " + name + "Qty: " + qty);
 
         }
         
     }
 
     return returnval;

}


function SaveMenuOptions(){

    if(currentMenuPane === 1){ // Bun

        burger.bun = getActiveBun();
    }

    if(currentMenuPane === 2){ // Beef
    
        burger.beefs = getSelectedBeefs();

    }

    if(currentMenuPane === 3){ // Cheese
    
        burger.cheeses = getSelectedCheeses();
    
    }

    if(currentMenuPane === 4){ // Sauce

        burger.sauces = getSelectedSauces();
    }

    if(currentMenuPane === 5){ // Extra

        burger.extras = getSelectedExtras();
    }


}


function NextMenuPane() {

    SaveMenuOptions();






    currentMenuPane++;

    if(currentMenuPane > 5){
        currentMenuPane = 1;
    }


}

function PreviousMenuPane() {

    SaveMenuOptions();

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

$(document).on("click", ".cheeseitem img", function () {

    console.log($(this)[0].parentNode.childNodes[7]);

    var element = $(this)[0].parentNode.childNodes[7];

    if (element.className === "nodisplay") {

        element.className = "";


    } else {

        element.className = "nodisplay";

    }


    console.log(burger);

});