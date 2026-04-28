---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides(System.String)
source: html/e642ca72-5c5a-80f4-a2e6-a98b874254e6.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.GetGraphicOverrides Method

Returns the graphic overrides assigned for elements owned by a particular user.

## Syntax (C#)
```csharp
public WorksharingDisplayGraphicSettings GetGraphicOverrides(
	string username
)
```

## Parameters
- **username** (`System.String`) - The username of a particular user.

## Returns
The graphic overrides assigned to this user.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This WorksharingDisplaySettings does not contain graphic overrides for the specified value of username.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

