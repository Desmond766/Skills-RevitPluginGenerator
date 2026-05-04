---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides(System.String,Autodesk.Revit.DB.WorksharingDisplayGraphicSettings)
source: html/8c1789ba-042d-a58e-594c-86da606d261b.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.SetGraphicOverrides Method

Sets the graphic overrides assigned to elements owned by a particular user.
 The username cannot be on the list of removed usernames.

## Syntax (C#)
```csharp
public void SetGraphicOverrides(
	string username,
	WorksharingDisplayGraphicSettings overrides
)
```

## Parameters
- **username** (`System.String`) - The username of the desired user.
- **overrides** (`Autodesk.Revit.DB.WorksharingDisplayGraphicSettings`) - The desired graphic overrides for this user.

## Remarks
Note that you can specify usernames which do not yet exist in the document's user table.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The username is on the list of removed users.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

