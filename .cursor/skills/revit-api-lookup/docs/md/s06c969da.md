---
kind: method
id: M:Autodesk.Revit.DB.Structure.IMemberForcesServer.MemberForcesUpdate(Autodesk.Revit.DB.Structure.MemberForcesServiceData)
source: html/dd28fd2a-809e-ef6b-5747-e8c42019cf03.htm
---
# Autodesk.Revit.DB.Structure.IMemberForcesServer.MemberForcesUpdate Method

The server's method that will be called when Revit User clicks Member Forces button in the MPP.

## Syntax (C#)
```csharp
bool MemberForcesUpdate(
	MemberForcesServiceData data
)
```

## Parameters
- **data** (`Autodesk.Revit.DB.Structure.MemberForcesServiceData`) - The Moment Forces data.

## Returns
Indicates whether themember forces parameter server is executed successfully.

## Remarks
The server provides UI way for Revit user to view and modify the detail data corresponding with the parameter value.
 The server may also modify the section type parameter value itself during the execution.
 The method should always return 'true' if the server is successfully executed, no matter whether the server changes anything.
 Return 'false' or if the server throws, indicates a failed case, all changes made by the server will be discarded.

