# Choice Button Layout

## Inspector

![Choice-Button-Layout-Inspector](_images\choice-button-layout-inspector.PNG)

* Item Prefab: The prefab for spawning buttons
* Item Per Row: The number of buttons per row
* Item Gap: The gap between each button

## Components

* `ItemMatrixLayout<T>`: The UI layout that arranging the created items in a matrix layout. `T` is the class inherited from `AbstractLayoutItem`.
* `AbstractLayoutItem`: The basic component for the created items. The prefab for `ItemMatrixLayout` to create items must contain the script inherited from this class.
* `ChoiceButtonLayout : ItemMatrixLayout<ChoiceButton>`: The layout for creating `ChoiceButton`s
* `ChoiceButton : AbstractLayoutItem`: The button inherited from `AbstractLayoutItem`

## API

* `ChoiceButtonLayout.CreateButtons(object[] data)`: Create buttons with specified data
* `ChoiceButtonLayout.InactivateAllExcept(int id)`: Inactivate all the buttons except the specified id
* `ChoiceButton.Initialize(int id, object data)`: Initialize the button with the provided data. This will be invoked by `ItemMatrixLayout` when creating buttons.
* `ChoiceButton.RegisterOnClick(UnityAction callback)`: Add a callback to the `button.OnClick` event
  * Some custom callback could be `RegisterOnClick(UnityAction<int> callback)`. The `int` argument is for passing the id of the button.

  ```csharp
  // In class ChoiceButton
  public void RegisterOnClick(UnityAction<int> callback)
  {
      button.onClick.AddListener(() => callback(id));
  }

  // In class ChoiceButtonLayout
  private void SetUp()
  {
      foreach (var button in buttons) {
          button.RegisterOnClick(InactivateAllExcept);
      }
  }
  ```
