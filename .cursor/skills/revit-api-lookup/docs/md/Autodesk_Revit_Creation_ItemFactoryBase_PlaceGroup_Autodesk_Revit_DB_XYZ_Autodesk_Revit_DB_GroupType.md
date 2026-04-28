---
kind: method
id: M:Autodesk.Revit.Creation.ItemFactoryBase.PlaceGroup(Autodesk.Revit.DB.XYZ,Autodesk.Revit.DB.GroupType)
source: html/586d4f2e-0985-2d0b-dbb7-ea6d2f704336.htm
---
# Autodesk.Revit.Creation.ItemFactoryBase.PlaceGroup Method

Place an instance of a Model Group into the Autodesk Revit document, using a location
and a group type.

## Syntax (C#)
```csharp
public Group PlaceGroup(
	XYZ location,
	GroupType groupType
)
```

## Parameters
- **location** (`Autodesk.Revit.DB.XYZ`) - The physical location where the group is to be placed.
- **groupType** (`Autodesk.Revit.DB.GroupType`) - A GroupType object that represents the type of group that is to be placed.

## Returns
If creation was successful then an instance to the new group is returned, otherwise Nothing nullptr a null reference ( Nothing in Visual Basic) .

## Remarks
This method is used to place a new instance of an existing group type within the document.
The group's origin will placed at the point specified by the location. All group types within the
document can be found by iterating over the document and looking for elements of type
 GroupType .

