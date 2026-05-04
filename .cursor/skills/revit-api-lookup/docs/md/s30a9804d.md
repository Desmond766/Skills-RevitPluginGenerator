---
kind: type
id: T:Autodesk.Revit.DB.ModelUpdatesStatus
source: html/2fc35e00-cdf2-8368-e6a6-032725492cbe.htm
---
# Autodesk.Revit.DB.ModelUpdatesStatus

Indicates whether an element in the current model has additional user changes in the central model.

## Syntax (C#)
```csharp
public enum ModelUpdatesStatus
```

## Remarks
Note that this status only indicates that the element has user changes in the central model.
 A user change is typically an action specifically taken by a user. Making a user change
 to an element requires that the user making the change reload all other user changes made to
 the element in the central model. Making a user change also causes the element to be
 checked out to the current user so other users will not be able to make user changes to
 the same element. Elements can also be modified by system changes. A system change is one which is done
 automatically by Revit to fully update the model after a user change occurs. Users may
 make changes to an element in their local model even if the element contains additional
 system changes in the central model. Example: Suppose Alice and Bob are working on the same model. Alice moves a wall which
 contains windows. Then Alice synchronizes with the central file. The wall was explicitly
 changed by Alice and so it will report as "UpdatedInCentral" in Bob's model. Bob
 would have to reload latest before he could make user changes to that wall. In contrast, Revit
 automatically moved the windows with the wall, so the windows do not contain any user changes.
 The windows would therefore report "CurrentWithCentral" and Bob would be allowed to
 modify them in his local model without reloading latest.

