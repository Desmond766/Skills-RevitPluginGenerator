---
kind: property
id: P:Autodesk.Revit.UI.PushButtonData.ClassName
zh: 按钮
source: html/e357858a-8d9a-7e9f-8ae6-aa526dbfa0c4.htm
---
# Autodesk.Revit.UI.PushButtonData.ClassName Property

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

