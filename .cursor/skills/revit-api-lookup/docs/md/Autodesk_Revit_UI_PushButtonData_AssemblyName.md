---
kind: property
id: P:Autodesk.Revit.UI.PushButtonData.AssemblyName
zh: 按钮
source: html/aac7ffb6-83c4-e2f9-2dd9-2ca5e87e6489.htm
---
# Autodesk.Revit.UI.PushButtonData.AssemblyName Property

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

