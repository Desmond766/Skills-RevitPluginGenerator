---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.SetMemberForces(Autodesk.Revit.DB.Structure.MemberForces)
source: html/53ccade9-6946-8c77-0e94-64b14e19104a.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.SetMemberForces Method

Sets Member Forces to Analytical Member.

## Syntax (C#)
```csharp
public void SetMemberForces(
	MemberForces memberForces
)
```

## Parameters
- **memberForces** (`Autodesk.Revit.DB.Structure.MemberForces`) - End to which member forces will be added is defined by setting [!:Autodesk::Revit::DB::Structure::MemberForces::Position] 
 property in provided Member Forces object.

## Remarks
If element already have member forces defined for that end, newly provided values replace current one.
 Member forces are strictly related with releases. This means that setting member forces values is reasonable only for directions that have releases set to false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

