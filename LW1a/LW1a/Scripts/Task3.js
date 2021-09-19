function OnClick_Header(x, y, z) {
    var req = new window.XMLHttpRequest();
    var patern = new RegExp(/^[0-9]*\.?[0-9]+$/);
    const formData = new FormData();
    formData.append("parmA", x.value);
    formData.append("parmB", y.value);
    if (patern.test(x.value) && patern.test(y.value)) {
        req.open("PUT", "http://localhost:52855/put_handler/", true);
        req.onreadystatechange = () => {
            if (req.readyState === 4) {
                if (req.status === 200) {
                    z.value = req.responseText;
                }
                else alert("status = " + req.status + "\n" + req.statusText);
            }
        };
        req.setRequestHeader("X", x.value);
        req.setRequestHeader("Y", y.value);
        req.send(formData);
    }
}
