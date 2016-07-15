//CdnPath=http://ajax.aspnetcdn.com/ajax/4.5.1/1/DetailsView.js
function DetailsView() {
    this.pageIndex = null;
    this.dataKeys = null;
    this.createPropertyString = DetailsDtocreatePropertyString;
    this.setStateField = DetailsDtosetStateValue;
    this.getHiddenFieldContents = DetailsDtogetHiddenFieldContents;
    this.stateField = null;
    this.panelElement = null;
    this.callback = null;
}
function DetailsDtocreatePropertyString() {
    return createPropertyStringFromValues_DetailsView(this.pageIndex, this.dataKeys);
}
function DetailsDtosetStateValue() {
    this.stateField.value = this.createPropertyString();
}
function DetailsDtoOnCallback (result, context) {
    var value = new String(result);
    var valsArray = value.split("|");
    var innerHtml = valsArray[2];
    for (var i = 3; i < valsArray.length; i++) {
        innerHtml += "|" + valsArray[i];
    }
    context.panelElement.innerHTML = innerHtml;
    context.stateField.value = createPropertyStringFromValues_DetailsView(valsArray[0], valsArray[1]);
}
function DetailsDtogetHiddenFieldContents(arg) {
    return arg + "|" + this.stateField.value;
}
function createPropertyStringFromValues_DetailsView(pageIndex, dataKeys) {
    var value = new Array(pageIndex, dataKeys);
    return value.join("|");
}
