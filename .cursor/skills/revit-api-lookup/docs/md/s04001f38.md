---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalPanel.Create(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.XYZ)
zh: 创建、新建、生成、建立、新增
source: html/11db06be-e308-06c0-b196-ec72ba459821.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalPanel.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new instance of an Analytical Panel within the project.

## Syntax (C#)
```csharp
public static AnalyticalPanel Create(
	Document document,
	Curve profile,
	XYZ normal
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Revit document.
- **profile** (`Autodesk.Revit.DB.Curve`) - Curve which represents the profile of the Analytical Panel.
- **normal** (`Autodesk.Revit.DB.XYZ`) - Normal used for the extrusion of the profile.

## Returns
The newly created AnalyticalPanel instance.

## Remarks
Profile can be a line, an arc or an ellipse.
 In case of arcs and ellipses, the normal should be perpendicular to the profile plane.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The profile argument is not valid for analytical panel creation.
 -or-
 The input profile is not bound.
 -or-
 The normal argument is not valid for analytical panel creation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to create the analytical panel.
- **Autodesk.Revit.Exceptions.ModificationForbiddenException** - The document is in failure mode: an operation has failed,
 and Revit requires the user to either cancel the operation
 or fix the problem (usually by deleting certain elements).
 -or-
 The document is being loaded, or is in the midst of another
 sensitive process.
- **Autodesk.Revit.Exceptions.ModificationOutsideTransactionException** - The document has no open transaction.

