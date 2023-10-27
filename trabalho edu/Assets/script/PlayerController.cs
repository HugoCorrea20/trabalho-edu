using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float velocidade = 5.0f;
    private Rigidbody rb;
    private Transform cameraTransform;
  

    void Start()
    {
        rb = GetComponent <Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Captura a entrada do jogador para movimentação
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Calcula o vetor de movimento com base na direção da câmera
        Vector3 movimento = CalculateMovementDirection(movimentoHorizontal, movimentoVertical);

        // Aplica força ao RigidBody para mover o personagem
        rb.AddForce(movimento * velocidade);
    }

    Vector3 CalculateMovementDirection(float horizontalInput, float verticalInput)
    {
        // Obtém a rotação da câmera
        float cameraYRotation = cameraTransform.eulerAngles.y;

        // Calcula a direção do movimento com base na rotação da câmera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Calcula a direção de movimento com base na entrada do jogador
        Vector3 movementDirection = (forward * verticalInput + right * horizontalInput).normalized;

        return movementDirection;
    }
}
