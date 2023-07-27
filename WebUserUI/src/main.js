/* eslint-disable no-magic-numbers */
const resultContainer = document.querySelector(".result");
const resultOutput = document.querySelector(".result__text");
const getAllButton = document.getElementById("getAll");
const getByIdButton = document.getElementById("getById");
const userIdGetInput = document.getElementById("userIdGet");
const createButton = document.getElementById("create");
const createUserDataTextarea = document.getElementById("createUserData");
const updateButton = document.getElementById("update");
const updateUserDataTextarea = document.getElementById("updateUserData");
const userIdUpdateInput = document.getElementById("userIdUpdate");
const deleteButton = document.getElementById("delete");
const userIdDeleteInput = document.getElementById("userIdDelete");

getAllButton.addEventListener("click", async event => {
  event.preventDefault();
  const response = await fetch("/api/users");
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
  resultContainer.classList.remove("result_hidden");
});

getByIdButton.addEventListener("click", async event => {
  event.preventDefault();
  const userId = userIdGetInput.value;
  const response = await fetch(`/api/users/${userId}`);
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
  resultContainer.classList.remove("result_hidden");
});

createButton.addEventListener("click", async event => {
  event.preventDefault();
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
  resultContainer.classList.remove("result_hidden");
});

updateButton.addEventListener("click", async event => {
  event.preventDefault();
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
  resultContainer.classList.remove("result_hidden");
});

deleteButton.addEventListener("click", async event => {
  event.preventDefault();
  const userId = userIdDeleteInput.value;
  const response = await fetch(`/api/users/${userId}`, {
    method: "delete",
  });
  const jsonString = JSON.stringify(await response.json(), null, 2);
  resultOutput.textContent = jsonString;
  resultContainer.classList.remove("result_hidden");
});
