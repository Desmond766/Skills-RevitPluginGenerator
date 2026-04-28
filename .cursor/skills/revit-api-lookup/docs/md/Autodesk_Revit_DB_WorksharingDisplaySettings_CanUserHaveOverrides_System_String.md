---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.CanUserHaveOverrides(System.String)
source: html/e50869c9-ce9d-6dad-44cf-e4d929b2196b.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.CanUserHaveOverrides Method

Checks whether a single username can have customized graphic overrides.

## Syntax (C#)
```csharp
public bool CanUserHaveOverrides(
	string username
)
```

## Parameters
- **username** (`System.String`) - The username to check.

## Returns
False if the username is on the list of removed users, True otherwise.

## Remarks
Only users that have not been removed can have overrides.
 Once it is removed, a username must be restored before its associated graphic overrides
 can be customized.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

