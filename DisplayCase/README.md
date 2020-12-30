- Create the display case object from the prefab
- Formed by 3 parts:
    - `DisplayCase`: The management class
    - `ItemContainer`: The place for holding items
    - `DragArea`: The area for detecting the dragging operation
- Inspector Properties:
    - Item Gap: The space between items in unit in the case
- Access the display case via class `DisplayCase`
    - `FillItems`: Initialize function. Fill items to the display case
    - `ReturnItem`: Return an item that is not removed from the case
      back to its position. This is function is used for just picking item.
    - `RemoveItem`: Remove an item from the display case
    - `AddItem`: Add an item to the display case. It will be at the top
      of the case
