---
kind: property
id: P:Autodesk.Revit.UI.PushButton.AssemblyName
zh: 按钮
source: html/0cf77ff0-48fb-b92a-62c4-fbb3543d8987.htm
---
# Autodesk.Revit.UI.PushButton.AssemblyName Property

**中文**: 按钮

The assembly path of the button.

## Syntax (C#)
```csharp
public string AssemblyName { get; set; }
```

## Remarks
The path of the assembly which contains the corresponding external command.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when setting the value to Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when setting the value to an empty string.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when setting the value to a ToggleButton which is not initialized with an external command.

