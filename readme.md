# Curso de RabbitMQ

## 1. Demo
- Exemplo básico

## 2. Introdução ao RabbitMQ
- História e origens do RabbitMQ como um message broker baseado em AMQP (Advanced Message Queuing Protocol).
- A importância dos message brokers na arquitetura de sistemas distribuídos.
- Visão geral da arquitetura do RabbitMQ, incluindo conceitos como produtores, consumidores, filas e trocas.

## 3. Instalação e configuração
- Requisitos de sistema, incluindo hardware e software necessários para executar o RabbitMQ.
- Instruções passo a passo para instalar o RabbitMQ em diferentes sistemas operacionais, como Linux, Windows e macOS.
- Configurações básicas, como definição de usuários, permissões e políticas de acesso, e configurações avançadas, como clustering e alta disponibilidade.

## 4. Conceitos fundamentais de RabbitMQ
- Papel dos produtores e consumidores na troca de mensagens.
- O que são filas e trocas, e como eles facilitam o encaminhamento de mensagens no RabbitMQ.
- Uso de bindings para conectar trocas e filas.

## 5. Tipos de troca (Exchanges)
- Explicação detalhada de cada tipo de troca suportado pelo RabbitMQ: Direct, Fanout, Topic e Headers.
- Cenários de uso para cada tipo de troca, destacando suas diferenças e vantagens.

## 6. Modelos de Mensagem
- Compreensão da diferença entre mensagens persistentes e não persistentes e quando usar cada uma.
- Discussão sobre o tamanho máximo de mensagem suportado pelo RabbitMQ e como isso pode afetar o design do sistema.
- Exemplos de formatos de mensagem comuns, como JSON, XML, e como eles podem ser manipulados pelo RabbitMQ.

## 7. Padrões de troca de mensagens
- Explicação dos padrões Publish/Subscribe e como eles podem ser implementados no RabbitMQ.
- Discussão sobre como usar filas de trabalho (Work Queues) para distribuir tarefas entre vários consumidores.
- Exemplos de roteamento de mensagens baseados em padrões, como o uso de chaves de roteamento em trocas de tópicos.

## 8. Confiabilidade e Garantias de Entrega
- Como o RabbitMQ garante a entrega de mensagens e como os produtores podem confirmar o recebimento das mensagens pelos consumidores.
- Uso de transações para garantir operações atômicas em mensagens.
- Estratégias para lidar com falhas e garantir a entrega de mensagens em ambientes de alta disponibilidade.

## 9. Integração com outras tecnologias
- Exemplos de integração do RabbitMQ com frameworks web populares, como Spring Boot no Java.
- Como o RabbitMQ pode ser usado para integrar sistemas legados com bancos de dados, sistemas de arquivos e outros sistemas de armazenamento.
- Uso de RabbitMQ em arquiteturas de microsserviços para comunicação assíncrona entre serviços.

## 10. Administração e Monitoramento
- Visão geral das ferramentas de linha de comando e interfaces gráficas para gerenciar e monitorar o RabbitMQ.
- Métricas importantes para monitorar o desempenho do RabbitMQ, como taxa de transferência de mensagens, tamanho das filas e utilização da CPU.
- Estratégias para ajustar o desempenho e a escalabilidade do RabbitMQ com base nos dados de monitoramento.

## 11. Segurança e Autenticação
- Configuração de usuários e permissões no RabbitMQ para garantir o acesso seguro ao sistema.
- Uso de TLS/SSL para criptografar a comunicação entre os componentes do RabbitMQ.
- Implementação de estratégias de autenticação e autorização personalizadas usando plugins do RabbitMQ.

## 12. Cenários Avançados e Casos de Uso
- Exploração de cenários avançados de implantação do RabbitMQ, como replicação e clustering para alta disponibilidade e escalabilidade.
- Discussão sobre como encaminhar mensagens entre clusters RabbitMQ distribuídos geograficamente.
- Uso de filas de dead-letter para lidar com mensagens não processadas e implementar estratégias de reprocessamento de mensagens.
