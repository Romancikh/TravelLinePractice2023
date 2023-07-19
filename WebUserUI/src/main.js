const resultContainer = document.getElementById("resultContainer");
const resultOutput = document.getElementById("result");
const getAllButton = document.getElementById("getAll");
const getButton = document.getElementById("get");
const userIdAddInput = document.getElementById("userIdAdd");
const createButton = document.getElementById("create");
const createUserDataTextarea = document.getElementById("createUserData");
const updateButton = document.getElementById("update");
const updateUserDataTextarea = document.getElementById("updateUserData");
const userIdUpdateInput = document.getElementById("userIdUpdate");
const deleteButton = document.getElementById("delete");
const userIdDeleteInput = document.getElementById("userIdDelete");

getAllButton.addEventListener("click", async event => {
  event.preventDefault();
  resultContainer.classList.remove("d-none");
  const response = await fetch("/api/users");
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
});

getButton.addEventListener("click", async event => {
  event.preventDefault();
  resultContainer.classList.remove("d-none");
  const userId = userIdAddInput.value;
  const response = await fetch(`/api/users/${userId}`);
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
});

createButton.addEventListener("click", async event => {
  event.preventDefault();
  resultContainer.classList.remove("d-none");
  const data = createUserDataTextarea.value;
  const response = await fetch(`/api/users`, {
    body: data,
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    method: "post",
  });
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
});

updateButton.addEventListener("click", async event => {
  event.preventDefault();
  resultContainer.classList.remove("d-none");
  const data = updateUserDataTextarea.value;
  const userId = userIdUpdateInput.value;
  const response = await fetch(`/api/users/${userId}`, {
    body: data,
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    method: "put",
  });
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
});

deleteButton.addEventListener("click", async event => {
  event.preventDefault();
  resultContainer.classList.remove("d-none");
  const userId = userIdDeleteInput.value;
  const response = await fetch(`/api/users/${userId}`, {
    method: "delete",
  });
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
});
