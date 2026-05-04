---
kind: method
id: M:Autodesk.Revit.DB.Structure.AnalyticalMember.GetMemberForces
source: html/5769b806-a243-f49d-b0d9-c0f793363cbf.htm
---
# Autodesk.Revit.DB.Structure.AnalyticalMember.GetMemberForces Method

Gets the member forces associated with this Analytical Member.

## Syntax (C#)
```csharp
public IList<MemberForces> GetMemberForces()
```

## Returns
Returns a collection of Member Forces associated with this Analytical Member. Empty collection will be returned if Analytical Member doesn't have any Member Forces.
 To find out with which end member forces are associated use [!:Autodesk::Revit::DB::Structure::MemberForces::Position] 
 property to obtain a position of Member Forces on element.

## Remarks
Member forces are strictly related with releases. This means that we can obtain member forces values only for directions that have releases set to false.
 Force or moment component on direction that have release set to true is skipped (zeroed) during getting.

