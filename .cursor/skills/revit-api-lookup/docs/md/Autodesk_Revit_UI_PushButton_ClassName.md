---
kind: property
id: P:Autodesk.Revit.UI.PushButton.ClassName
zh: 按钮
source: html/791aa519-daeb-0bf5-b407-230db90a3b96.htm
---
# Autodesk.Revit.UI.PushButton.ClassName Property

**中文**: 按钮

The name of the class containing the implementation for the command.

## Syntax (C#)
```csharp
public string ClassName { get; set; }
```

## Remarks
The class name which implements the interface IExternalCommand.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when setting the value to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting the value to an empty string.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting the value to a ToggleButton which is not initialized with an external command.

