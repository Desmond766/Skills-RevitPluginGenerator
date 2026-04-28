---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.GetAllUsersWithGraphicOverrides
source: html/4df2c37c-fca2-80a3-980d-50a478220c58.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.GetAllUsersWithGraphicOverrides Method

Returns all usernames that have graphic overrides. This list consists of
 all users included in the user table + all users who have explicitly been
 assigned overrides.

## Syntax (C#)
```csharp
public ICollection<string> GetAllUsersWithGraphicOverrides()
```

## Returns
All usernames that have been assigned graphic overrides.

