---
kind: property
id: P:Autodesk.Revit.UI.FilterDialog.FilterToSelect
source: html/73b71ec0-6769-a135-0fa1-f3d35835cda2.htm
---
# Autodesk.Revit.UI.FilterDialog.FilterToSelect Property

The filter element to be selected once Show is invoked.

## Syntax (C#)
```csharp
public ElementId FilterToSelect { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The supplied ElementId id is not of a FilterElement.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null

