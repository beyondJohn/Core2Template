var editModuleClick = function (ev) {
    btnType = ev.innerHTML;
    var index = 0;
    if (ev.innerHTML === "Edit") {
        console.log(ev.innerHTML + "HI");
        index = ev.id.split("btnEdit")[1];
        activeIndex = index;
    }
    maskClick();
    console.log(ev.innerHTML + ev);
}