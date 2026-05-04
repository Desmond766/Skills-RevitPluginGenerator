---
kind: property
id: P:Autodesk.Revit.ApplicationServices.Application.LoginUserId
source: html/8d3b257a-7b99-a6ee-b146-f635c35f425c.htm
---
# Autodesk.Revit.ApplicationServices.Application.LoginUserId Property

The user id of the user currently logged in. The user id will be empty
 if the user is not logged in.

## Syntax (C#)
```csharp
public string LoginUserId { get; }
```

## Remarks
The internal id of Autodesk ID that the current user has logged in to A360.
 This user id is in human unrecognizable form. In conjunction with the Store Entitlement REST
 API, a publisher of Autodesk Exchange Store app can verify if the current user has purchased
 their app from the store. For more information about Store Entitlement API, please refer
 to www.autodesk.com/developapps.

