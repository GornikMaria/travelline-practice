import "./style.css";

const API_URL = "https://localhost:7263";

async function getUser() {
  const userId = document.getElementById("getUserById").value;
  try {
    const response = await fetch(`${API_URL}/users/${userId}`);
    const data = await response.json();
    document.getElementById("getUserResponse").textContent = JSON.stringify(data, null, 2);
  } catch (error) {
    console.error("Ошибка при получении пользователя:", error);
  }
}
document.getElementById("getUserButton").addEventListener("click", getUser);


async function getAllUsers() {
  try {
    const response = await fetch(`${API_URL}/users`);
    const data = await response.json();
    document.getElementById("getUsersResponse").textContent = JSON.stringify(data, null, 2);
  } catch (error) {
    console.error("Ошибка при получении списка пользователей:", error);
  }
}
document.getElementById("apiGetAll").addEventListener("click", getAllUsers);


async function createUser() {
  const userData = document.getElementById("textarea-request-create").value.trim();
  try {
    const response = await fetch(`${API_URL}/users`, {
      body: userData,
      headers: {
        "Content-Type": "application/json",
      },
      method: "POST",
    });
    const data = await response.json();
    document.getElementById("createOneResponseTextarea").textContent = JSON.stringify(data, null, 2);
  } catch (error) {
    console.error("Ошибка при добавлении пользователя:", error);
  }
}
document.getElementById("apiCreateUser").addEventListener("click", createUser);


async function updateUser() {
  const userId = document.getElementById("updateUserById").value;
  const userData = document.getElementById("updateUserRequestBody").value.trim();
  try {
    const response = await fetch(`${API_URL}/users/${userId}`, {
      body: userData,
      headers: {
        "Content-Type": "application/json",
      },
      method: "PUT",
    });
    const data = await response.json();
    document.getElementById("updateUserResponse").textContent = JSON.stringify(data, null, 2);
  } catch (error) {
    console.error("Ошибка при обновлении данных пользователя:", error);
  }
}
document.getElementById("updateUserButton").addEventListener("click", updateUser);


async function deleteUser() {
  const userId = document.getElementById("deleteUserById").value;
  try {
    const response = await fetch(`${API_URL}/users/${userId}`, {
      method: "DELETE",
    });
    const data = await response.json();
    document.getElementById("deleteUserResponse").textContent = JSON.stringify(data, null, 2);
  } catch (error) {
    console.error("Ошибка при удалении пользователя:", error);
  }
}
document.getElementById("deleteUserButton").addEventListener("click", deleteUser);
