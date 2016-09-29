#Assignment B1 Group 02

## Report

1. Raycast from the position of agent to the sheerPoint to detect whether some other agents block the front path. Stop when blocked. At the same time, raycast to the right direction and make the same effects to keep distance from other agents.

2. Raycast to the front will be helpful when moving without carving.

3. As follows:
	1.	If the carving option is on, agents will change directions immediately when the obstacle stay in the way. On the contrary, agents will move as before until they collide with the obstacle. 
	2. If we make all obstacles carving, the agent won't be able to find a path to the destination if there are dynamic obstacles on the way.
	3. If we make all obstacles not carving, we will find obstacles overlap with each other. For example, your player may stuck in the wall or box in the game Counter Strike(BTW that is a interesting bug, many people do like it).


##Extra Credit

* My Nazgul agent has the NavMeshAgent and NavMeshObstacle at the same time.  The Shape of NavMeshObstacle is a  very large cube. The trick is Nazgul is shorter than other normal agents, then the NavMeshObstacle cube is just above the agent while it still can collide with other normal agents. Then Nazgul agent not only can move seamlessly but  also far away from other agents.


## Basic Environment

* The white parts contain a maze and several rooms, which are all static game object.

* Blue stairs are be stepped on, and three different height platform has generated 1-way off-mesh links.  Specially, on the shallow blue one has constructed an off-mesh-link (connector) manually.

* Blue slices have various costs which will affect the navigation path.

* There are 5 normal agents and one nazgul agent in the scene, they will follow the click point.

* Green blocks and purple blocks are navMeshObstacles. Those of green are controllable, while others are moving along the sine curve.

# Details about how the assignment requirements are fulfilled
In this assignment ,we are asked to learn Navigation knowledge in Unity. It includes some agents, static and dynamic obstacles, maze, room, bottleneck areas, off-mesh link, jumping blocks, free look cameras and different weights planes.

###Game control guides are as follows:

1. Scroll the wheel to zoom. Pushing mouse with middle key, you can translate the camera. Push "ctrl" key and mouse right key at the same time, you can rotate the camera.
2. To select an agent, you can click the left mouse button and drag, the agent in the area that you drag will be selected. Click the right mouse button to tell the agent where to go.
3. To control 2 green obstacle in the scene, use "space" key. Also using "space" key to switch between two green obstacels. Use arrow keys to control obstacle's directions.

###For basic requirement:

1. You can use mouse to control the free look camera.
2. There are obstacles, maze, several rooms, Bottleneck Area(red cuboid), 1-way off-mesh links(the dark blue stairs), connector between unconnected planes(between Bottlenect(red cuboid) and the while room beside it).
3. Check navigation in the Unity.
4. Check while cylinder agent in the scene.
5. Check agent.
6. Check agent.
7. The two green obstacles in the scene fulfill the requirements.

###Refined Navigation:

1. With Raycast, the agent won't bunch up.
2. Check dynamic obstacles in the scene.
3. Check the big dark blue area on the one side of the scene. With navigation panel in the unity, you can find they in fact have different weights with different colors.

###Extra Credit:
Notice there is a cube agent while the other agents are in fact cylinder agents. The cube agent is the "Nazgul" agent. This Nazgul agent has the NavMeshAgent and NavMeshObstacle at the same time. The Shape of NavMeshObstacle is a very large cube. The trick is Nazgul is shorter than other normal agents, then the NavMeshObstacle cube is just above the agent while it still can cylinder with other normal agents. Then Nazgul agent not only can move seamlessly but also keep other agents away from it.