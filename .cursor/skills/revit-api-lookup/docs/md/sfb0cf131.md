---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarConstraintsManager
source: html/32fe1ec6-ddb3-feac-f18c-8683b054f639.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraintsManager

A class used to obtain information about the constraints (RebarConstraints) acting
 on the shape handles (RebarConstrainedHandles) of a Rebar element, and modify the constraints.

## Syntax (C#)
```csharp
public class RebarConstraintsManager : IDisposable
```

## Remarks
A RebarConstraintsManager is created by calling Rebar.GetRebarConstraintsManager(),
 and can only be used to query or change constraints on the rebar element that
 created it. There are two types of constraint manager, depending on the type of Rebar that created it:
 Shape Driven constraints and FreeForm constraints -----ShapeDriven----- If the Rebar is Shape Driven, Revit uses the following logic to choose constraints for each handle
 on a rebar element. First, a search is performed to find all suitable target
 planes, including surfaces of the rebar's host, as well as surfaces on other
 concrete host elements that are attached to the rebar's host. In the case of
 standard style rebar, any host surface occupied by a stirrup will be ignored,
 and instead, the handles on the stirrup itself will be treated as candidates
 to form a constraint. Once all the constraint target candidates have been determined, the following
 sequence is used to select a constraint target:
 If the rebar is a straight standard bar, it will search the list of candidates
 for stirrup bends to lock its RebarPlane and Edge handles. If a bend is found within
 tolerance distance, then the bar will be snapped and constrained to that bend. The bar will snap and constrain its handle to any host cover or stirrup handle
 that lies within tolerance distance. If no candidate is found within tolerance, then the bar will choose nearest
 host surface target, with or without cover, and create a constant distance constraint
 to that surface. Snapping tolerances are 0.5 * bar diameter for host surface cover constraints and
 0.5 * (bar diameter + stirrup bar diameter) for stirrup handle constraints. The RebarConstraintsManager allows the API developer to obtain the constraint
 candidates for each constrained handle on a rebar, and to override the default
 target selection logic by setting a particular constraint as preferred. This
 can be useful in a number of ways. First, it can be used to snap a handle to a
 particular host surface or stirrup rebar handle, or to position a handle at a
 precise distance from a host surface. Second, it can force a rebar handle to
 constrain itself to a particular target surface, even if other targets are closer
 (or will become closer in subsequent updates of the Revit model). For example,
 a bar can be constrained to maintain a constant offset distance from a face of
 an opening in a slab, even if the opening is placed close to the edge of the slab
 and the bar would normally constrain itself to the slab edge. Lastly, the override
 can be used to cancel the default standard bar preference for stirrup bar handle
 planes, and to allow standard bars to be constrained to host cover surfaces, even
 when a stirrup is present. ----- FreeForm ----- If the rebar is FreeForm, then it requires input constraints that will be consumed to
 obtain the actual shape of the bar. The calculation method of the constraints passed
 to the rebar is custom made by an API application - IRebarUpdateServer . The RebarConstraintsManager can return all the possible "shape" handles
 and can set constraints created only with one of those handles.
 There are only active constraints on a FreeForm bar, the current and preferred notions
 represent the same thing.

