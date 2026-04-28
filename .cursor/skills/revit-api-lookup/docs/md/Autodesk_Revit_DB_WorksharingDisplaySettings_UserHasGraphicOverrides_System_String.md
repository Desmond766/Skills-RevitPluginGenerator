---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.UserHasGraphicOverrides(System.String)
source: html/84a5e6ac-480e-cc1e-936c-912f22080c1d.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.UserHasGraphicOverrides Method

Checks whether there are graphic overrides that would apply to elements
 owned by the given user in the "Individual Owners" display mode.

## Syntax (C#)
```csharp
public bool UserHasGraphicOverrides(
	string username
)
```

## Parameters
- **username** (`System.String`) - The username to check

## Returns
True if there are graphic overrides assigned to the username, false otherwise.

## Remarks
There will always be graphic overrides for all users included in the user
 table. In addition, there may be other users who have been explicitly assigned overrides.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

