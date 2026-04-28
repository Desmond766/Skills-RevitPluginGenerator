---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewControl(Autodesk.Revit.DB.ControlShape,Autodesk.Revit.DB.View,Autodesk.Revit.DB.XYZ)
source: html/6fea0f30-e0ea-8398-62d2-3b95e88e4a50.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewControl Method

Add a new control into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Control NewControl(
	ControlShape controlShape,
	View view,
	XYZ origin
)
```

## Parameters
- **controlShape** (`Autodesk.Revit.DB.ControlShape`) - The shape of the control.
- **view** (`Autodesk.Revit.DB.View`) - The view in which the control is to be visible. It
must be a FloorPlan view or a CeilingPlan view.
- **origin** (`Autodesk.Revit.DB.XYZ`) - The origin of the control.

## Returns
If successful, the newly created control is returned, otherwise an
exception with error information will be thrown.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-"view" or "position"-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-"view"-is invalid.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Thrown when the input argument-"controlType"-is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when control creation failed.

