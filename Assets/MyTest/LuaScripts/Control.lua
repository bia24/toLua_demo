--global table 
Control={}
UI={}

--get module
local Input=UnityEngine.Input
local Vector3=UnityEngine.Vector3
local Debugger=LuaInterface.Debugger
local Space=UnityEngine.Space
local Time=UnityEngine.Time
local Resources=UnityEngine.Resources
local Random=UnityEngine.Random
local Instantiate=UnityEngine.Object.Instantiate
local Quaternion=UnityEngine.Quaternion



--hot fix function
function Control.PlayerSphereMove(playerRigidbody,speed)
	
	h=Input.GetAxis("Horizontal")
	v=Input.GetAxis("Vertical")

	playerRigidbody.velocity=Vector3(h,0,v)*20*speed

end

function Control.GameEnd(playerRigidbody)

	playerRigidbody.velocity=Vector3.zero
	if(Control.goldBuilderCo~=nil)then
		coroutine.stop(Control.goldBuilderCo)
		Control.goldBuilderCo=nil
		print("Stop Coroutine Build Gold")
		--clear the gold in the scence
		local golds=UnityEngine.GameObject.FindGameObjectsWithTag('Gold')
		for i=0,golds.Length-1 do
			UnityEngine.Object.Destroy(System.Array.GetValue(golds,i))
		end
	end
end

function Control.GoldControl(transform)

	local rotate=Vector3(0,Time.deltaTime,0)*5
	transform:Rotate(rotate,Space.World)

end


--cor
local function CoGoldBuilder(go)
	local Y = -0.5
    local XMAX = 6.51
    local XMIN = -10.25
    local ZMAX = 7.68
    local ZMIN = -8.84
    print("StartCoroutine Build Gold")
    while true do
    	for i=1,3 do
    		local pos=Vector3(UnityEngine.Random.Range(XMIN,XMAX),Y,UnityEngine.Random.Range(ZMIN,ZMAX))
    		local g=Instantiate(go,pos,go.transform.rotation)
    		g.tag='Gold'
    	end
    	coroutine.wait(5)
    end
end



function Control.GoldBuilder()
	local go=Resources.Load("Prefabs/Gold")
	Control.goldBuilderCo=coroutine.start(CoGoldBuilder,go)
end





function UI.OnScoreTextAdd(score)
	return score+1
end
		
