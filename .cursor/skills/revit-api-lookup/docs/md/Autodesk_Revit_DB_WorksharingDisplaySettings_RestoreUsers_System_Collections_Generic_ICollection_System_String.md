---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.RestoreUsers(System.Collections.Generic.ICollection{System.String})
source: html/da4f0c9e-3c5d-1869-3351-5c93d815fe7a.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.RestoreUsers Method

Adds users back to the list of displayed users and permits customization of the graphics.
 Any usernames that are not currently removed will be ignored.
 Returns the number of users who were actually restored.

## Syntax (C#)
```csharp
public int RestoreUsers(
	ICollection<string> usersToRestore
)
```

## Parameters
- **usersToRestore** (`System.Collections.Generic.ICollection < String >`) - The usernames of the users to restore. Any usernames that are not currently removed will
 be ignored.

## Returns
The number of usernames that were actually restored.

## Remarks
This is the opposite of removing users.
 Note that the user will be shown with default graphic overrides - any customizations that
 existed prior to removing the user will not be restored.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

