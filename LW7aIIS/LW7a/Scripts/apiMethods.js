function loadPhones() {
    const xhttp = new XMLHttpRequest();
    var baseURL = 'http://172.16.193.234:41201/LW7a/api/TS/'
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            collectPhones( this.responseText)
        }
    };
    xhttp.open("GET", baseURL);
    xhttp.send();
}

function AcceptAdding() {
    let addingBlock = document.getElementById('addingBlock')
    if (addingBlock == null)
        return
    let name = addingBlock.querySelector('[id="Name"]').value
    let phoneNumber = addingBlock.querySelector('[id="PhoneNumber"]').value

    let phoneReord = { name, phoneNumber }

    const xhttp = new XMLHttpRequest();
    var baseURL = 'http://172.16.193.234:41201/LW7a/api/TS/'
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            loadPhones()
        }
    };
    xhttp.open("POST", baseURL);
    xhttp.setRequestHeader("Content-Type", "application/json")
    let bady = JSON.stringify(phoneReord)
    xhttp.send(bady);
}

function AcceptEditing(id) {

    let callingObj = event.target
    let edditingBlock = $(callingObj).closest('tr')[0];
    if (edditingBlock == null)
        return
    let name = edditingBlock.querySelector('[id="Name"]').value
    let phoneNumber = edditingBlock.querySelector('[id="PhoneNumber"]').value

    let phoneReord = { id, name, phoneNumber }

    const xhttp = new XMLHttpRequest();
    var baseURL = 'http://172.16.193.234:41201/LW7a/api/TS/'
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            loadPhones()
        }
    };
    xhttp.open("PUT", baseURL);
    xhttp.setRequestHeader("Content-Type", "application/json")
    let bady = JSON.stringify(phoneReord)
    xhttp.send(bady);
}


function CancelEditing(id) {

    var callingObj = event.target
    let record = $(callingObj).closest('tr')[0];
    const xhttp = new XMLHttpRequest();
    var baseURL = 'http://172.16.193.234:41201/LW7a/api/TS/'
    let phoneRecord
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            phoneRecord = JSON.parse(this.responseText)
        }
    };
    xhttp.open("GET", baseURL + id, false);
    xhttp.send();

    record.innerHTML = `
                    <td>
                        ${phoneRecord.Name}
                    </td>
                    <td>
                        ${phoneRecord.PhoneNumber}
                    </td>
                    <td>
                        <input type = 'button' onClick="editPhone(${phoneRecord.Id})" value='Edit'/> |
                        <input type = 'button' onClick="deletePhone(${phoneRecord.Id})" value='Delete'/>
                    </td>
                 `
}

function CancelAdding() {

    let addingBlock = document.getElementById('addingBlock')
    if (addingBlock == null)
        return
    addingBlock.remove()
}


function collectPhones(phones) {
    var phoneTable = document.createElement('div');
    phoneTable.innerHTML = 
        `<table class="table">
            <tbody>
                <tr>
                    <th>
                        Name
                    </th>
                    <th>
                        PhoneNumber
                    </th>
                    <th></th>
                </tr>
            </tbody>
        </table>`
    let phonesObj = JSON.parse(phones)
    for (let i = 0; i < phonesObj.length; i++ ) {
        let tt = document.createElement('tr')
        tt.innerHTML =`
                <tr>
                    <td>
                        ${phonesObj[i].Name}
                    </td>
                    <td>
                        ${phonesObj[i].PhoneNumber}
                    </td>
                    <td>
                        <input type = 'button' onClick="editPhone(${phonesObj[i].Id})" value='Edit'/> |
                        <input type = 'button' onClick="deletePhone(${phonesObj[i].Id})" value='Delete'/>
                    </td>
                </tr> `
        let tbady = phoneTable.getElementsByTagName('tbody')[0]
        tbady.appendChild(tt)
    }

    var table = document.getElementById('container')
    table.innerHTML = phoneTable.innerHTML

}

function addPhone() {
    if (document.getElementById('addingBlock') != null)
        return

    let addingBlock = document.createElement('tr')

    addingBlock.innerHTML = `
                <tr>
                    <td>
                        <input id='Name' name='Name' type='text' value/>
                    </td>
                    <td>
                        <input id='PhoneNumber' name='PhoneNumber' type='text' value />
                    </td>
                    <td>
                        <input type = 'button' onClick = AcceptAdding() value='Add'/> |
                        <input type = 'button' onClick ="CancelAdding()" value='Cancel'/>
                    </td>
                </tr>`
    addingBlock.id ='addingBlock'
    let container = document.getElementsByTagName("tbody")[0]
    if (container != null && container.value != '') {
        container.appendChild(addingBlock)
    }
    

}

function deletePhone(id) {
    const xhttp = new XMLHttpRequest();
    var baseURL = 'http://172.16.193.234:41201/LW7a/api/TS/'
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            loadPhones()
        }
    };

    xhttp.open("DELETE", baseURL);
    xhttp.setRequestHeader("Content-Type", "application/json")
    let bady = JSON.stringify(id)
    xhttp.send(bady);
}

function editPhone(id) {

    var callingObj = event.target
    let record = $(callingObj).closest('tr')[0];
    const xhttp = new XMLHttpRequest();
    var baseURL = 'http://172.16.193.234:41201/LW7a/api/TS/'
    let phoneRecord
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            phoneRecord = JSON.parse(this.responseText)
        }
    };
    xhttp.open("GET", baseURL + id, false);
    xhttp.send();
    let temp = record.innerHTML
    record.innerHTML = `
                    <td>
                        <input id='Name' name='Name' type='text' value="${phoneRecord.Name}"/>
                    </td>
                    <td>
                        <input id='PhoneNumber' name='PhoneNumber' type='text' value="${phoneRecord.PhoneNumber}" />
                    </td>
                    <td>
                        <input type = 'button' onClick ="AcceptEditing(${phoneRecord.Id})" value='Save'/> |
                        <input type = 'button' onClick ="CancelEditing(${phoneRecord.Id})" value='Cancel'/>
                    </td>`


}