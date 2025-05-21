# CommandApp (C# Console Application)

## 🛠 Features

- Increment the current value by 1
- Decrement the current value by 1
- Double the current value
- Add a random number between 1 and 10
- Undo the last operation

---

## ▶️ How to Run

1. **Open in Visual Studio**.
2. Add a command-line argument in the Debug settings (e.g., `5`).
   - Go to: `Project Properties > Debug > Open debug launch profiles UI`
   - Add an initial number under **Command line arguments**
3. Press `Ctrl + F5` to run without debugging.

---

## 💻 Commands

Type one of the following commands in the console when prompted:

| Command    | Description                      |
|------------|----------------------------------|
| `increment`| Adds 1 to the current result     |
| `decrement`| Subtracts 1 from the result      |
| `double`   | Doubles the current result       |
| `randadd`  | Adds a random number (1–10)      |
| `undo`     | Undoes the last operation        |

---

## ✅ Example Usage

Enter command (increment, decrement, double, randadd, undo): increment
Result: 6
Enter command: double
Result: 12
Enter command: undo
Result: 6
Enter command: randadd
Result: 13




## 📚 Concepts Used

- **Command Design Pattern**: Each operation is encapsulated as a class.
- **Interfaces**: `ICommand` interface defines contract for commands.
- **Stack**: Used for tracking command history and enabling undo.
- **Abstraction**: Operations are abstracted into reusable components.

---

## 👨‍💻 Author

This application was built as a coding task to demonstrate knowledge in C# object-oriented programming and design patterns.



