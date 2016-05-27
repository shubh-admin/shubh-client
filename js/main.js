function SetCursorToTextEnd(textControlID) {
    var text = document.getElementById(textControlID);
    if (text != null && text.innerHTML.length > 0) {
        if (document.selection) {
            var range = document.selection.createRange();
            range.moveStart('character', text.innerHTML.length);
            range.collapse();
            range.select();
        }
        else if (window.getSelection) {

            var range = window.getSelection().getRangeAt(0);
            if (range.startContainer.nodeName == "#text") {

                range.setStart(range.startContainer, text.innerHTML.length);
                range.setEnd(range.startContainer, text.innerHTML.length);
            }
            else {
                window.getSelection().removeAllRanges();
                var div = document.createRange();
                if (text.childNodes.length > 0 && text.childNodes[0].nodeName == "#text") {
                    div.setStart(text.childNodes[0], text.innerHTML.length);
                    div.setEnd(text.childNodes[0], text.innerHTML.length);
                    window.getSelection().addRange(div);
                }
            }


        }
    }
}