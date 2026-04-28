---
kind: method
id: M:Autodesk.Revit.DB.WorksharingDisplaySettings.RemoveUsers(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{System.String},System.Collections.Generic.ICollection{System.String}@)
source: html/d714db4a-2b0e-e8da-2002-3508a3d71772.htm
---
# Autodesk.Revit.DB.WorksharingDisplaySettings.RemoveUsers Method

Removes users from the list of displayed users and permanently discards any customization of the graphics.
 Note that a user cannot be removed if he or she owns any elements.

## Syntax (C#)
```csharp
public void RemoveUsers(
	Document document,
	ICollection<string> usersToRemove,
	out ICollection<string> usersActuallyRemoved
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing this.
- **usersToRemove** (`System.Collections.Generic.ICollection < String >`) - The usernames of the users to remove.
- **usersActuallyRemoved** (`System.Collections.Generic.ICollection < String > %`) - The users that were successfully removed. Note that you cannot remove
 users who currently own any elements.

## Remarks
Note that default graphic overrides will be applied to any elements owned by these
 users if they take ownership of any elements or worksets while they are removed.
 Note also that the list of removed users will be shared by all users of the central model and
 will remove all customizations by all users.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

