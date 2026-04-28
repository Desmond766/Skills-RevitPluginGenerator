---
kind: method
id: M:Autodesk.Revit.DB.ProjectLocation.Duplicate(System.String)
source: html/18ada300-7084-2281-63c8-13c40e14e5b7.htm
---
# Autodesk.Revit.DB.ProjectLocation.Duplicate Method

Generate a copy of this project location with the specified name.

## Syntax (C#)
```csharp
public ProjectLocation Duplicate(
	string name
)
```

## Parameters
- **name** (`System.String`)

## Returns
A new ProjectLocation which is a duplicate of this location, with
 the input name.

## Remarks
The name must not be the same as the name of any existing locations.
 This function will modify the document, as the new ProjectLocation
 will be added to it.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

