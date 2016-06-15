function numbersonly(e) {
    var unicode = e.charCode ? e.charCode : e.keyCode
    if (unicode != 8 && unicode != 44) {
        if (unicode < 48 || unicode > 57) //if not a number
        { return false } //disable key press    
    }
}

function soloLetras(evt) {

    var charCode = (evt.which) ? evt.which : event.keyCode;

    if ((charCode > 64 && charCode < 91)
        || (charCode > 96 && charCode < 123)
        || charCode == 32)

        return true;

    return false;
}

function soloLetrasNumeros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;

    if ((charCode > 64 && charCode < 91)
       || (charCode > 96 && charCode < 123)//Minusculas
         || (charCode > 47 && charCode < 58)//Numeros
         || (charCode > 47 && charCode < 58)//mayusculas
         || (charCode == 45)//-
         || (charCode == 165)//Ñ
         || (charCode == 164)//ñ
         || (charCode == 135)//á
         || (charCode == 231)//Á
         || (charCode == 142)//é
         || (charCode == 131)//É
         || (charCode == 146)//í
         || (charCode == 234)//Í
         || (charCode == 151)//ó
         || (charCode == 238)//Ó
         || (charCode == 156)//ú
         || (charCode == 242)//Ú
         || charCode == 32)// espacio

        return true;

    return false;
}
//permite caracteres como , y .
function soloLetrasNumerosCaracteres(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;

    if ((charCode > 64 && charCode < 91)
                 || (charCode > 96 && charCode < 123)//Minusculas
                 || (charCode > 47 && charCode < 58)//Numeros
                 || (charCode > 47 && charCode < 58)//mayusculas
                 || (charCode == 45)//-
                 || (charCode == 46)//.
                 || (charCode == 44)//,
                 || (charCode == 239)//´
                 || (charCode == 209)//Ñ
                 || (charCode == 241)//ñ
                 || (charCode == 225)//á
                 || (charCode == 231)//Á
                 || (charCode == 233)//é
                 || (charCode == 201)//É
                 || (charCode == 237)//í
                 || (charCode == 205)//Í
                 || (charCode == 243)//ó
                 || (charCode == 211)//Ó
                 || (charCode == 250)//ú
                 || (charCode == 218)//Ú
                 || charCode == 32)// espacio

        return true;

    return false;

}

function OnTreeClick(evt) {
    var src = window.event != window.undefined ? window.event.srcElement : evt.target;
    var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
    if (isChkBoxClick) {
        var parentTable = GetParentByTagName("table", src);
        var nxtSibling = parentTable.nextSibling;
        //check if nxt sibling is not null & is an element node
        if (nxtSibling && nxtSibling.nodeType == 1) {
            if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
            {
                //check or uncheck children at all levels
                CheckUncheckChildren(parentTable.nextSibling, src.checked);
            }
        }
        //check or uncheck parents at all levels
        CheckUncheckParents(src, src.checked);
    }
}
function CheckUncheckChildren(childContainer, check) {
    var childChkBoxes = childContainer.getElementsByTagName("input");
    var childChkBoxCount = childChkBoxes.length;
    for (var i = 0; i < childChkBoxCount; i++) {
        childChkBoxes[i].checked = check;
    }
}
function CheckUncheckParents(srcChild, check) {
    var parentDiv = GetParentByTagName("div", srcChild);
    var parentNodeTable = parentDiv.previousSibling;
    if (parentNodeTable) {
        var checkUncheckSwitch;
        if (check) //checkbox checked
        {
            var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
            if (isAllSiblingsChecked)
                checkUncheckSwitch = true;
            else
                return; //do not need to check parent if any(one or more) child not checked
        }
        else //checkbox unchecked
        {
            checkUncheckSwitch = false;
        }
        var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
        if (inpElemsInParentTable.length > 0) {
            var parentNodeChkBox = inpElemsInParentTable[0];
            parentNodeChkBox.checked = checkUncheckSwitch;
            //do the same recursively
            CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
        }
    }
}
function AreAllSiblingsChecked(chkBox) {
    var parentDiv = GetParentByTagName("div", chkBox);
    var childCount = parentDiv.childNodes.length;
    for (var i = 0; i < childCount; i++) {
        if (parentDiv.childNodes[i].nodeType == 1) {
            //check if the child node is an element node
            if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                //if any of sibling nodes are not checked, return false
                if (!prevChkBox.checked) {
                    return false;
                }
            }
        }
    }
    return true;
}
function GetParentByTagName(parentTagName, childElementObj) {
    var parent = childElementObj.parentNode;
    while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
        parent = parent.parentNode;
    }
    return parent;
}
function ValidaListBox(sender, args) {
    var lb = document.getElementById(sender.controltovalidate);
    if (lb.children.length == 0) {
        args.IsValid = false;
    }
    else {
        args.IsValid = true;
    }
}

function ValidaCheckBoxList(sender, args) {
    var chkList = document.getElementById(sender.controltovalidate);
    var chkListinputs = chkList.getElementsByTagName("input");

    for (var i = 0; i < chkListinputs.length; i++) {
        if (chkListinputs[i].checked) {
            args.IsValid = true;
            return;
        }
    }
    args.IsValid = false;
}
function ConfirmarTexto(texto) {

    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";
    var conf = confirm(texto);

    if (conf == true) {
        confirm_value.value = "Yes";

    }
    else {
        confirm_value.value = "No";

    }
    document.forms[0].appendChild(confirm_value);
}
